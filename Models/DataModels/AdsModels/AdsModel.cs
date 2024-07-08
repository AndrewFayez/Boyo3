using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.PostModel
{
    public class AdsModel
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Description { get; set; } 
        public string Warranty { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        /// ////////////////////////////////////////////////
        public string AdsType { get; set; } = "AdsType";
        public string? ColorIn { get; set; } = "ColorIn";
        public string? ColorOut { get; set; } = "";
        public string? YearMake { get; set; } = "";
        public int? Cylinders { get; set; } = 0;
        public int? Kilometer { get; set; } = 0;
        public string? AddOns { get; set; } = "";
        public string? PublicStatus { get; set; } = "";
        public string? Faults { get; set; } = "";
        public string? Security { get; set; } = "";
        public string? Specifications { get; set; } = "";
        public string? Size { get; set; } = ""; 
        public string? GeneratorType { get; set; } = "";
        public string? AirConditionType { get; set; } = "";
        public string? AirConditionSize { get; set; } = "";
        public string? AirConditionCount { get; set; } = ""; 
        public string? NormalOrSaylant { get; set; } = "";
        public int? NumberOfParson { get; set; } = 0;
        public int? Height { get; set; } = 0;

        public DateTime CreatedDate { get; set; }
        public bool? IsApproved { get; set; } = false;


        public virtual ICollection<UserAds> UserAds { get; set; }
        public virtual ICollection<AdsForPackage>  AdsForPackages { get; set; }



    }
}
