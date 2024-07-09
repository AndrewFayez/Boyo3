namespace BYO3WebAPI.Models.DataModels.UserModel
{
    public class RegisterModel
    {
        public string? FullName { get; set; }
        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Phonenumber { get; set; }

        public string? longitude { get; set; }

        public string? latitude { get; set; }

        public IFormFile? ImageCover { get; set; }
        public bool? IsAdmin { get; set; }=false;

       // public DateTime? DateTime { get; set; }


    }
}
