﻿using BYO3WebAPI.Helpers;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DataModel.TokenDataModel;
using BYO3WebAPI.Models.DataModels.UserModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BYO3WebAPI.Services.Users
{
    public class AuthService : ControllerBase, IAuthService
    {




        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _host;
        private readonly ApplicationDbContext _db;

        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, IWebHostEnvironment host, ApplicationDbContext db)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _host = host;
            _db = db;

        }





        public async Task<AuthModel> RegistrationAsync(RegisterModel model)
        {


            var userEmail = await _db.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower());
            if (userEmail != null)
                return new AuthModel { Message = "Email or UserName is already registered!" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Email or UserName is already registered!" };



            if (model.ImageCover == null || model.ImageCover.Length == 0)
            {
                 return new AuthModel { Message = "StaticFile/Images/NoImage.jpeg" };
            }

            string randem1 = Guid.NewGuid().ToString();

            string path1 = Path.Combine("StaticFile/Images/", $"{randem1}_{model.ImageCover.FileName}");
            string fullPath1 = Path.Combine(_host.ContentRootPath.ToString(), path1);

            using (var stream = new FileStream(fullPath1, FileMode.Create))
            {
                await model.ImageCover.CopyToAsync(stream);
            }


            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.Username,
                PhoneNumber = model.Phonenumber,
                Email = model.Email.ToLower(),
                ImageCover = path1,
                longitude = model.longitude,
                latitude = model.latitude,
                DateTime = DateTime.Now,
                IsAdmin = false,
 
            };

            
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }


            var jwtSecurityToken = await CreateJwtToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthModel
            {

                Message = "Register Success",
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn,
                Id=user.Id,
                IsAdmin = (bool)user.IsAdmin
            };
            
           
        }



        public async Task<Messages> UpdateSubProfile([FromRoute] string id, [FromBody] RegisterModel prof)
        {
            var c = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return new Messages {Message = $"Client Id {id} Not Exists"};
            }


            if (c.ImageCover == null || c.ImageCover.Length == 0 || prof.ImageCover != null)
            {
                string randem1 = Guid.NewGuid().ToString();

                string pathcover = Path.Combine("StaticFile/Images/", $"{randem1}_{prof.ImageCover.FileName}");

                string fullPath2 = Path.Combine(_host.ContentRootPath.ToString(), pathcover);

                using (var stream = new FileStream(fullPath2, FileMode.Create))
                {
                    await prof.ImageCover.CopyToAsync(stream);
                }
                c.ImageCover = pathcover;
            }

            c.ImageCover = c.ImageCover;



            if (prof.FullName == null)
                c.FullName = c.FullName;
            else
                c.FullName = prof.FullName;

            if (prof.Username == null)
                c.UserName = c.UserName;
            else
                c.UserName = prof.Username;


            if (prof.Email == null)
                c.Email = c.Email;
            else
                c.Email = prof.Email;
            if (prof.Phonenumber == null)
                c.PhoneNumber = c.PhoneNumber;
            else
                c.PhoneNumber = prof.Phonenumber;


            if (prof.latitude == null)
                c.latitude = c.latitude;
            else
                c.latitude = prof.latitude;

            if (prof.longitude == null)
                c.longitude = c.longitude;
            else
                c.longitude = prof.longitude;

          
            await _userManager.UpdateAsync(c);

            return new Messages { Message = $"{c.FullName}" };


        }




        public async  Task<AuthModel>  GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();
             

            var user = await  _userManager.Users.SingleOrDefaultAsync(x=>x.Email.ToLower()==model.Email.ToLower());

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {

                   return new AuthModel { Message = "Email or Password is incorrect!" };

            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.Message = "Success";
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Id = user.Id;
            authModel.IsAdmin = (bool)user.IsAdmin;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return  authModel  ;
        }




        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }



        //public async Task<string> AddRoleAsync(AddRoleModel model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.UserId);

        //    if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
        //        return "Invalid user ID or Role";

        //    if (await _userManager.IsInRoleAsync(user, model.Role))
        //        return "User already assigned to this role";

        //    var result = await _userManager.AddToRoleAsync(user, model.Role);

        //    return result.Succeeded ? string.Empty : "Sonething went wrong";
        //}

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.Message = " Success";

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.IsAdmin = (bool)user.IsAdmin;

            var roles = await _userManager.GetRolesAsync(user);
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }

        
    }
}
