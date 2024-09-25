using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;

namespace BYO3WebAPI.Models.DataModels.AdsPackageModels
{
    public class AdsForPackage
    {
        public int AdsId { get; set; }
        public virtual AdsModel Ads { get; set; }

        public int PackageId { get; set; }
        public virtual AdsPackageModel Package { get; set; }
    }
}
