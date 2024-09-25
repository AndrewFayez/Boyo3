using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.ServicePackageModel
{
    public class ServicePackageModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ValidityDay { get; set; } = 0;
        public int FeaturedAds { get; set; } = 0;
        public string Sections { get; set; }
        public int price { get; set; }

        public virtual ICollection<UserServicePackage> UserservicePackage { get; set; }
        public virtual ICollection<ServiceForPackage> ServiceForPackage { get; set; }



    }
}
