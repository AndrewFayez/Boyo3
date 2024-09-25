using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchInAdsAndServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SearchInAdsAndServiceController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("SearchInAdsUsingName")]
        public async Task<IActionResult> SearchInAds(string Name)
        {

            var result = await _db.Ads.Where(x => x.Title.ToLower().Contains(Name.ToLower())
            || x.Title.ToLower().Contains(Name.ToLower()))
               .SelectMany(x => x.UserAds.Where(x=>x.Ads.IsApproved==true).Select(x => new
               {
                   x.Ads.Id,
                   UserId = x.User.Id,
                   x.User.FullName,
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
            return Ok(result);

        }

        [HttpGet("SearchInAdsUsingPrice")]
        public async Task<IActionResult> SearchInAdsUsingPrice(decimal? minPrice, decimal? maxPrice)
        {
            var prices = await _db.Ads
            .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
              .SelectMany(x => x.UserAds.Where(x=>x.Ads.IsApproved==true).Select(x => new
              {
                  x.Ads.Id,
                  UserId = x.User.Id,
                  x.User.FullName,
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
            return Ok(prices);
        }




        [HttpGet("SearchInServiceUsingName")]
        public async Task<IActionResult> SearchInService(string Name)
        {

            var result = await _db.Service.Where(x => x.Title.ToLower().Contains(Name.ToLower())
            || x.Title.ToLower().Contains(Name.ToLower()))
               .SelectMany(x => x.UserService.Where(x=>x.Service.IsApproved == true).Select(x => new
               {
                   x.Service.Id,
                   UserId = x.User.Id,
                   x.User.FullName,
                   x.Service.Title,
                   x.Service.Description,
                   x.Service.WhatsAppNumber,
                   x.Service.Type1,
                   x.Service.Type2,
                   x.Service.Type3,
                   x.Service.Image1,
                   x.Service.Image2,
                   x.Service.Image3,
                   x.Service.City,
                   x.Service.Country,
                   x.Service.CreatedDate,
                   x.Service.Longitude,
                   x.Service.Latitude,
                   x.Service.PhoneNumber,
                   x.Service.Price,
                   x.Service.Warranty,
                   x.Service.IsApproved,
               })).ToListAsync();
            return Ok(result);

        }

        [HttpGet("SearchInServiceUsingPrice")]
        public async Task<IActionResult> SearchInServiceUsingPrice(decimal? minPrice, decimal? maxPrice)
        {
            var prices = await _db.Service
            .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
              .SelectMany(x => x.UserService.Where(x=>x.Service.IsApproved == true).Select(x => new
              {
                  x.Service.Id,
                  UserId = x.User.Id,
                  x.User.FullName,
                  x.Service.Title,
                  x.Service.Description,
                  x.Service.WhatsAppNumber,
                  x.Service.Type1,
                  x.Service.Type2,
                  x.Service.Type3,
                  x.Service.Image1,
                  x.Service.Image2,
                  x.Service.Image3,
                   x.Service.City,
                  x.Service.Country,
                  x.Service.CreatedDate,
                  x.Service.Longitude,
                  x.Service.Latitude,
                  x.Service.PhoneNumber,
                  x.Service.Price,
                  x.Service.Warranty,
                  x.Service.IsApproved
              })).ToListAsync();
            return Ok(prices);
        }

    }
}
