using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DataModel.TokenDataModel;
using BYO3WebAPI.Models.DataModels.UserModel;
using Microsoft.AspNetCore.Mvc;


namespace BYO3WebAPI.Services.Users
{

    public interface IAuthService
    {
       
        Task<AuthModel> RegistrationAsync(RegisterModel model);

         Task<AuthModel> GetTokenAsync(TokenRequestModel model);


        public  Task<Messages> UpdateSubProfile([FromRoute] string id, [FromBody] RegisterModel patch);


        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);


    }




}
