using BYO3WebAPI.Models.Data;

namespace BYO3WebAPI.Models.DataModels.PackageModels
{
    public class UserAdsPackage
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int PackageId { get; set; }
        public virtual AdsPackageModel Package { get; set; }
    }
}
