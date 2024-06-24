namespace BYO3WebAPI.DTOModels
{
    public class DTOService
    {

        public string Title { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }

        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Description { get; set; }
        public string Warranty { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }

        public int CountDay { get; set; }
        public int CountPerson { get; set; }
        public string FromCountry { get; set; }
        public string ToCountry { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
