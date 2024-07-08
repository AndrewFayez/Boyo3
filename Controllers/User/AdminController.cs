using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetAllAds/Pending")]
        public async Task<IActionResult> GetAllAdsPending()
        {
            var posts = await _db.Ads
                 .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == false).Select(x => new
                 {
                     x.Ads.Id,
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
            return Ok(posts);
        }


        [HttpGet("GetOneAdsPending")]
        public async Task<IActionResult> GetOneAdsPending(int id)
        {
            var posts = _db.Ads.Where(x => x.Id == id).SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == false).Select(x => new
            {
                x.Ads.Id,
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
            }));
            return Ok(posts);
        }



        [HttpPut("ApprovedOnAds")]
        public async Task<IActionResult> AdminIsApproved([FromForm] int id)
        {

            var Ads = await _db.Ads.SingleOrDefaultAsync(x => x.Id == id);
            if (Ads == null )
            {
                return NotFound(new { Messages = $"Ads Id {id} Not Exists Or IsApproved" });
            }

            if (Ads.IsApproved==false)
                Ads.IsApproved = true;


            var userAds = _db.UserAds
                 .Where(x => x.AdsId == id).Select(x=>x.User.FullName);

            _db.Ads.Update(Ads);
            _db.SaveChanges();


            return Ok(
                new {
                     Ads.Id,
                     userAds,
                     Ads.Title,
                     Ads.Description,
                     Ads.WhatsAppNumber,
                     Ads.Type1,
                     Ads.Type2,
                     Ads.Type3,
                     Ads.Type4,
                     Ads.Image1,
                     Ads.Image2,
                     Ads.Image3,
                     Ads.Country,
                     Ads.City,
                     Ads.CreatedDate,
                     Ads.Longitude,
                     Ads.Latitude,
                     Ads.PhoneNumber,
                     Ads.Price,
                     Ads.Warranty,
                     Ads.Security,
                     Ads.Height,
                     Ads.GeneratorType,
                     Ads.Size,
                     Ads.AddOns,
                     Ads.AirConditionCount,
                     Ads.AirConditionSize,
                     Ads.AirConditionType,
                     Ads.ColorIn,
                     Ads.ColorOut,
                     Ads.Cylinders,
                     Ads.Kilometer,
                     Ads.NormalOrSaylant,
                     Ads.NumberOfParson,
                     Ads.PublicStatus,
                     Ads.Specifications,
                     Ads.YearMake,
                     Ads.Faults,
                     Ads.AdsType,
                     Ads.IsApproved
                });

        }



    }
}
