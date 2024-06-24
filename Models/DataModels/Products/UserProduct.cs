using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PostModel;

namespace BYO3WebAPI.Models.DataModels.Products
{
    public class UserProduct
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
