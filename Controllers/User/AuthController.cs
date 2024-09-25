using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DataModel.TokenDataModel;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.UserModel;
using BYO3WebAPI.Services.Email;
using BYO3WebAPI.Services.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.User
{
    [EnableCors("AllowAll")]

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;


        public AuthController(IAuthService authService, IEmailSender emailSender, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _db = db;
            _emailSender = emailSender;
            _userManager = userManager;

        }


        [HttpPost("Register/User")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModel model)
        {

            //return Ok("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegistrationAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(new { Messages = $"{result.Message}" });


            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromForm] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(new { Messages = result.Message });

            return Ok(result);
        }



        [HttpPut("UpdateSubProfile/{id}")]
        public async Task<IActionResult> UpdateSubProfil([FromRoute] string id, [FromForm] RegisterModel patch)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _authService.UpdateSubProfile(id, patch);
            return Ok(result);
        }


        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(string userId, string newPassword, string oldPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { Message = "User Not Found." });
            }

            if (user is null || !await _userManager.CheckPasswordAsync(user, oldPassword))
            {

                return NotFound(new { Message = "Old Password Is Incorrect!" });
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "Password Is Updated!" });
        }




        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }




        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }


        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }




        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {

            var user = await _db.Users
                .Select(x => new
                {
                    x.Id,
                    x.FullName,
                    x.PhoneNumber,
                    x.UserName,
                    x.Email,
                    x.CountAds,
                    x.CountService,
                    x.DateTime,
                    x.IsAdmin,
                }).ToListAsync();
            return Ok(user);
        }



        [HttpGet("GetOneUser")]
        public async Task<IActionResult> GetOneUser(string userId)
        {

            var user = await _db.Users.Where(x=>x.Id==userId)
                .Select(x => new
                {
                    x.Id,
                    x.FullName,
                    x.PhoneNumber,
                    x.UserName,
                    x.Email,
                    x.CountAds,
                    x.CountService,
                    x.DateTime,
                    x.IsAdmin,
                }).ToListAsync();
            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {

            var user = await _db.Users
         .Include(u => u.UserAds)
         .Include(u => u.UserPackage)
         .Include(u => u.UserProduct)
         .Include(u => u.UserService)
         .Include(u => u.UserservicePackage)
         .Include(u => u.UserNews)
         .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            _db.UserAds.RemoveRange(user.UserAds);
            _db.UserPackage.RemoveRange(user.UserPackage);
            _db.UserProduct.RemoveRange(user.UserProduct);
            _db.UserService.RemoveRange(user.UserService);
            _db.UserServicePackage.RemoveRange(user.UserservicePackage);
            _db.UserNews.RemoveRange(user.UserNews);

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Ok();
        }



    }
}
