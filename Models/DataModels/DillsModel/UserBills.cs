using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PostModel;

namespace BYO3WebAPI.Models.DataModels.DillsModel
{
    public class UserBills
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int BillId { get; set; }
        public virtual BillModel Bill { get; set; }
    }
}
