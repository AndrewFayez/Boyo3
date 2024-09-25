using BYO3WebAPI.Models.Data;

namespace BYO3WebAPI.Models.DataModels.ServicePackageModel
{
    public class UserServicePackage
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int PackageId { get; set; }
        public virtual ServicePackageModel Package { get; set; }
    }
}
