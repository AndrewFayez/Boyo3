using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.ServiceModel;

namespace BYO3WebAPI.Models.DataModels.ServicePackageModel
{
    public class ServiceForPackage
    {
        public int ServiceId { get; set; }
        public virtual ServiceModels Service { get; set; }

        public int ServicePackageId { get; set; }
        public virtual ServicePackageModel ServicePackage { get; set; }
    }
}
