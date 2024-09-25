using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PostModel;

namespace BYO3WebAPI.Models.DataModels.ServiceModel
{
    public class UserService
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ServiceId { get; set; }
        public virtual ServiceModels Service { get; set; }
    }
}
