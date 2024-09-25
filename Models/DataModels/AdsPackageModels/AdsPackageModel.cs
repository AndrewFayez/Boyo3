using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.PackageModels
{
    public class AdsPackageModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ValidityDay { get; set; } = 0;
        public int FeaturedAds { get; set; } = 0;
        public string Sections { get; set; }
        public int price { get; set; }

        public virtual ICollection<UserAdsPackage> UserAdsPackage { get; set; }
        public virtual ICollection<AdsForPackage>  AdsForPackages { get; set; }



    }
}
