using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModel.OTPModel
{
    public class OTPEmailModel
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
    }
}
