using BYO3WebAPI.Models.DataModel.TokenDataModel;
using BYO3WebAPI.Models.DataModels.DillsModel;
using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.Products;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using BYO3WebAPI.Models.DataModels.ServicePackageModel;
using Microsoft.AspNetCore.Identity;

namespace BYO3WebAPI.Models.Data
{
    public class ApplicationUser : IdentityUser
    {

        public string? FullName { get; set; }
   
        public string? Email { get; set; }


        public string? longitude { get; set; }

        public string? latitude { get; set; }
        public string? ImageCover { get; set; }
        public int? CountAds { get; set; } = 0;
        public int? CountService { get; set; } = 0;
        public bool? IsAdmin { get; set; }=false;

        public DateTime? DateTime { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        public virtual ICollection<UserAds> UserAds { get; set; }
        public virtual ICollection<UserNews> UserNews { get; set; }

        public virtual ICollection<UserService> UserService { get; set; }
        public virtual ICollection<UserAdsPackage> UserPackage { get; set; }
        public virtual ICollection<UserProduct> UserProduct { get; set; }

        public virtual ICollection<UserServicePackage> UserservicePackage { get; set; }

        public virtual ICollection<UserBills> UserBills { get; set; }



    }
}
