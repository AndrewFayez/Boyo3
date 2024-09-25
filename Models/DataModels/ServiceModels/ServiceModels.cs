using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.ServicePackageModel;
using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.ServiceModel
{
    public class ServiceModels
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Description { get; set; }
        public string Warranty { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int CountDay { get; set; } = 0;
        public int CountPerson { get; set; } = 0;
        public string FromCountry { get; set; }
        public string ToCountry { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool? IsApproved { get; set; }

        public virtual ICollection<UserService> UserService { get; set; }
        public virtual ICollection<ServiceForPackage> ServiceForPackage { get; set; }


    }
}
