using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BYO3WebAPI.Controllers.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterAdsPackageController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FilterAdsPackageController(ApplicationDbContext db)
        {
            _db = db;
        }




        [HttpGet("GetAllAdsGoldCaravan")]
        public async Task<IActionResult> GetAllAdsGoldCaravan()
        {
                
            var pac = await _db.Package.Where(x => x.Title == "Gold")
                .SelectMany(x => x.UserAdsPackage.
                SelectMany(x=>x.User.UserAds.Where(x=>x.Ads.Type1=="caravan" && x.Ads.AdsType == "Gold"&& x.Ads.IsApproved==true)
                .Select(
                    x => new {
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
                    }
                    ))).ToListAsync();

            return Ok(pac);    
            
        }




        [HttpGet("GetAllAdsGoldCar")]
        public async Task<IActionResult> GetAllAdsGoldCar()
        {
            var pac = await _db.Package.Where(x => x.Title == "Gold")
               .SelectMany(x => x.UserAdsPackage.
               SelectMany(x => x.User.UserAds.Where(x => x.Ads.Type1 == "cars" && x.Ads.AdsType=="Gold" && x.Ads.IsApproved== true)
               .Select(
                   x => new {
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
                   }
                   ))).ToListAsync();



            return Ok(pac);
        }





        [HttpGet("GetAllAdsGoldMotorcycles")]
        public async Task<IActionResult> GetAllAdsGoldMotorcycles()
        {
          
                  var pac = await _db.Package.Where(x => x.Title == "Gold")
                .SelectMany(x => x.UserAdsPackage.
                SelectMany(x => x.User.UserAds.Where(x => x.Ads.Type1 == "motorcycles" && x.Ads.AdsType == "Gold" && x.Ads.IsApproved == true)
                .Select(
                    x => new {
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
                    }
                    ))).ToListAsync();



            return Ok(pac);
        }




        [HttpGet("GetAllAdsGoldTools")]
        public async Task<IActionResult> GetAllAdsGoldTools()
        {
            var pac = await _db.Package.Where(x => x.Title == "Gold")
             .SelectMany(x => x.UserAdsPackage.
             SelectMany(x => x.User.UserAds.Where(x => x.Ads.Type1 == "tools" && x.Ads.AdsType == "Gold" && x.Ads.IsApproved == true)
             .Select(
                 x => new {
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
                 }
                 ))).ToListAsync();

            return Ok(pac);
        }




        [HttpGet("GetAllAdsGold")]
        public async Task<IActionResult> GetAllAdsGold()
        {

            var pac = await _db.Package.Where(x => x.Title == "Gold")
          .SelectMany(x => x.UserAdsPackage.
          SelectMany(x => x.User.UserAds.Where(x=> x.Ads.AdsType == "Gold" && x.Ads.IsApproved == true)
          .Select(
              x => new {
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
              }
              ))).ToListAsync();



            return Ok(pac);
        }



    }
}
