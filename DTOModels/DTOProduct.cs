namespace BYO3WebAPI.DTOModels
{
    public class DTOProduct
    {
        public string? ProductNameArabic { get; set; }
        public string? ProductNameEnglish { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public string? Describtion { get; set; }
        public string? Content { get; set; }
        public int? price { get; set; }
        public int? quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
