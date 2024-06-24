using BYO3WebAPI.Helpers;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DTOModel;
using BYO3WebAPI.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using static System.Net.WebRequestMethods;

namespace BYO3WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {


        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailController(IEmailSender emailSender, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _emailSender = emailSender;
            _db = db;
            _userManager = userManager;
        }

        [HttpPost("Send Email/{email}")]
        public async Task<Messages> SendMail(string email)
        {
            var otp = OtpGenerator.GenerateOtp();
            var receiver = email;
            var subject = "Confirmation Email";
            var message = $"Security Code : {otp}";
            await _emailSender.SendEmailAsync(receiver, subject, message);
            var result = new OTPEmailModel
            {
                Email = email,
                OTP = otp
            };
            await _db.OTPEmail.AddAsync(result);
            await _db.SaveChangesAsync();

            return new Messages { Message = "Send OTP Successfully" };


        }


        [HttpGet("Send Confirmation Email/{otp}")]
        public async Task<Messages> VerificationOTP(string otp)
        {
            var verify = _db.OTPEmail.FirstOrDefault(x => x.OTP == otp);


            if (verify != null && verify.OTP == otp)
            {
                return new Messages { Message = "Verify Successfully..." };


            }
            return new Messages { Message = "Not Verify.. !" };

        }


        [HttpPost("ResetPassword")]
        public async Task<Messages> ResetPassword([FromForm] ChangePassword model)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
            {
                return new Messages { Message = "User Not Found...!" };

            }
            if (model.NewPassword != model.ConfirmPassword)
            {
                return new Messages { Message = "Error Write Password Again...!" };

            }

            var Currentpassword = await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, model.NewPassword);

            _db.SaveChanges();

            return new Messages { Message = $"Changed Successfully..." };
        }






    }
}
