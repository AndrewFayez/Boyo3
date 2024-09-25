using BYO3WebAPI.Models.Data;

namespace BYO3WebAPI.Models.DataModels.PostModel
{
    public class UserAds
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int AdsId { get; set; }
        public virtual AdsModel Ads { get; set; }
    }
}
