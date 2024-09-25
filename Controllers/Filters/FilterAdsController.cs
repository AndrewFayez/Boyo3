using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BYO3WebAPI.Controllers.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterAdsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FilterAdsController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet("GetAllAdsType1AndType2")]
        public async Task<IActionResult> GetAllAdsType1And2(string ads1, string ads2)
        {
            DTOAds dTOAds = new DTOAds();
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => 
                new {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.Country,
                    x.Ads.City,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved
                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsType2AndType3")]
        public async Task<IActionResult> GetAllAdsType2And3(string ads3, string ads2)
        {
            var caravan =await _db.Ads.Where(x => x.Type2 == ads3 && x.Type3 == ads2)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.Country,
                    x.Ads.City,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved
                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType1AndType3")]
        public async Task<IActionResult> GetAllAdsType1And3(string ads1, string ads2)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type3 == ads2)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved
                })).ToListAsync();
            return Ok(caravan);
        }


        [HttpGet("GetAllAdsType1AndType4")]
        public async Task<IActionResult> GetAllAdsType1And4(string ads1, string ads4)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type4 == ads4)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved
                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType1AndType2And4")]
        public async Task<IActionResult> GetAllAdsType1And2And4(string ads1, string ads2, string ads4)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Type4 == ads4)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,
                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsType1AndType2And3And4")]
        public async Task<IActionResult> GetAllAdsType1And2And3And4(string ads1, string ads2, string ads3, string ads4)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Type3 == ads3 && x.Type4 == ads4)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }


        [HttpGet("GetAllAdsType1AndCountry")]
        public async Task<IActionResult> GetAllAdsType1AndCountry(string ads1, string Country)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Country == Country)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.IsApproved,
                    x.Ads.AdsType,
                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType1And2AndCountry")]
        public async Task<IActionResult> GetAllAdsType1And2AndCountry(string ads1, string ads2, string Country)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Country == Country)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.IsApproved,
                    x.Ads.AdsType,
                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsType1AndType2And4Country")]
        public async Task<IActionResult> GetAllAdsType1AndType2And4Country(string ads1, string ads2, string ads4, string country)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Country == country && x.Type4 == ads4)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.IsApproved,
                    x.Ads.AdsType,
                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType1AndType2And3And4Country")]
        public async Task<IActionResult> GetAllAdsType1AndType2And3And4AndCountry(string ads1, string ads2, string ads3, string ads4, string country)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Type3 == ads3 && x.Country == country && x.Type4 == ads4)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsType1AndType2And3")]
        public async Task<IActionResult> GetAllAdsType1AndType2And3(string ads1, string ads2, string ads3)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.Type3 == ads3)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType1")]
        public async Task<IActionResult> GetAllAdsType1(string ads)
        {
            var caravan =await _db.Ads.Where(x => x.Type1 == ads)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType2")]
        public async Task<IActionResult> GetAllAdsType2(string ads)
        {
            var caravan =await _db.Ads.Where(x => x.Type2 == ads)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }




        [HttpGet("GetAllAdsType3")]
        public async Task<IActionResult> GetAllAdsType3(string ads)
        {
            var caravan = await _db.Ads.Where(x => x.Type3 == ads)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }


        [HttpGet("GetAllAdsType4")]
        public async Task<IActionResult> GetAllAdsType4(string ads)
        {
            var caravan = await _db.Ads.Where(x => x.Type4 == ads)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsCountry")]
        public async Task<IActionResult> GetAllAdsCountry(string country)
        {
            var caravan =await _db.Ads.Where(x => x.Country == country)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }

        [HttpGet("GetAllAdsCity")]
        public async Task<IActionResult> GetAllAdsCity(string city)
        {
            var caravan = await _db.Ads.Where(x => x.City == city)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }

        [HttpGet("GetAllAdsCountryAndCity")]
        public async Task<IActionResult> GetAllAdsCountryAndCity(string country, string city)
        {
            var caravan = await _db.Ads.Where(x => x.Country == country && x.City == city)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }


        [HttpGet("GetAllAdsType1And2AndCity")]
        public async Task<IActionResult> GetAllAdsType1And2AndCity(string ads1, string ads2, string city)
        {
            var caravan = await _db.Ads.Where(x => x.Type1 == ads1 && x.Type2 == ads2 && x.City == city)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }



        [HttpGet("GetAllAdsType1AndCity")]
        public async Task<IActionResult> GetAllAdsType1AndCity(string ads1,  string city)
        {
            var caravan = await _db.Ads.Where(x => x.Type1 == ads1  && x.City == city)
                .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
                {
                    x.Ads.Id,
                    x.User.FullName,
                    UserId= x.User.Id,
                    x.Ads.Title,
                    x.Ads.Description,
                    x.Ads.WhatsAppNumber,
                    x.Ads.Type1,
                    x.Ads.Type2,
                    x.Ads.Type3,
                    x.Ads.Type4,
                    x.Ads.Image1,
                    x.Ads.Image2,
                    x.Ads.Image3,
                    x.Ads.City,
                    x.Ads.Country,
                    x.Ads.CreatedDate,
                    x.Ads.Longitude,
                    x.Ads.Latitude,
                    x.Ads.PhoneNumber,
                    x.Ads.Price,
                    x.Ads.Warranty,
                    x.Ads.Security,
                    x.Ads.Height,
                    x.Ads.GeneratorType,
                    x.Ads.Size,
                    x.Ads.AddOns,
                    x.Ads.AirConditionCount,
                    x.Ads.AirConditionSize,
                    x.Ads.AirConditionType,
                    x.Ads.ColorIn,
                    x.Ads.ColorOut,
                    x.Ads.Cylinders,
                    x.Ads.Kilometer,
                    x.Ads.NormalOrSaylant,
                    x.Ads.NumberOfParson,
                    x.Ads.PublicStatus,
                    x.Ads.Specifications,
                    x.Ads.YearMake,
                    x.Ads.Faults,
                    x.Ads.AdsType,
                    x.Ads.IsApproved,

                })).ToListAsync();
            return Ok(caravan);
        }



    }
}
