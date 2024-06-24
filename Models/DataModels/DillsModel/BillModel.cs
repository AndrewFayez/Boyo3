using BYO3WebAPI.Models.DataModels.PostModel;

namespace BYO3WebAPI.Models.DataModels.DillsModel
{
    public class BillModel
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public DateTime DateTime  { get; set; }

        public virtual ICollection<UserBills> UserBills { get; set; }
        public virtual ICollection<BillProducts> BillProducts { get; set; }


    }
}
