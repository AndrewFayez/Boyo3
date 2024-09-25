using BYO3WebAPI.Models.DataModels.DillsModel;
using BYO3WebAPI.Models.DataModels.PostModel;
using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.Products
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string? ProductNameArabic { get; set; }
        public string? ProductNameEnglish { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Describtion { get; set; }
        public string? Content { get; set; }
        public int? price { get; set; }
        public int? quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<UserProduct> UserProduct { get; set; }

        public virtual ICollection<BillProducts> BillProducts { get; set; }

    }
}
