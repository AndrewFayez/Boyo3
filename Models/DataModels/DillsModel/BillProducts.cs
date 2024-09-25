using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.Products;

namespace BYO3WebAPI.Models.DataModels.DillsModel
{
    public class BillProducts
    {
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }
        public int Quentity { get; set; }
        public int BillId { get; set; }
        public virtual BillModel Bill { get; set; }
    }
}
