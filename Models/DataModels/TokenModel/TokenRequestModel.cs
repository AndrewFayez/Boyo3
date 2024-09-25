using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModel.TokenDataModel
{
    public class TokenRequestModel
    {
        [Required]

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
