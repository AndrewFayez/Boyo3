using BYO3WebAPI.Models.Data;

namespace BYO3WebAPI.Models.DataModels.PostModel
{
    public class UserNews
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int NewsId { get; set; }
        public virtual NewsModel news { get; set; }
    }
}
