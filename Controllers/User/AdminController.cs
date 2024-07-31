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


        [HttpPut("IsAdmin/AddAdmin/{userId}")]
        public async Task<IActionResult> AddAdmin(string userId)
        {

            var Ads = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (Ads == null)
            {
                return NotFound(new { Messages = $"User Id {userId} Not Exists Or IsAdmin" });
            }

            if (Ads.IsAdmin == false)
                Ads.IsAdmin = true;


            _db.Users.Update(Ads);
            _db.SaveChanges();


            return Ok(
                new
                {
                    Ads.Id,
                    Ads.FullName,
                    Ads.PhoneNumber,
                    Ads.UserName,
                    Ads.Email,
                    Ads.CountAds,
                    Ads.CountService,
                    Ads.DateTime,
                    Ads.IsAdmin,
                });

        }



        [HttpGet("GetAllAds/Pending")]
        public async Task<IActionResult> GetAllAdsPending()
        {
            var posts = await _db.Ads
                 .SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == false).Select(x => new
                 {
                     x.Ads.Id,
                     x.User.FullName,
                     UserId =x.User.Id,
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



        [HttpGet("GetOneAds/Pending")]
        public async Task<IActionResult> GetOneAdsPending(int id)
        {
            var posts = _db.Ads.Where(x => x.Id == id).SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == false).Select(x => new
            {
                x.Ads.Id,
                x.User.FullName,
                     UserId =x.User.Id,
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



        [HttpPut("ApprovedOn/Ads/{id}")]
        public async Task<IActionResult> AdminIsApproved( int id)
        {

            var Ads = await _db.Ads.SingleOrDefaultAsync(x => x.Id == id);
            if (Ads == null )
            {
                return NotFound(new { Messages = $"Ads Id {id} Not Exists Or IsApproved" });
            }

            if (Ads.IsApproved==false)
                Ads.IsApproved = true;


            var userAds = _db.UserAds
                 .Where(x => x.AdsId == id).Select(x=>new { x.User.FullName ,x.User.Id});

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





        [HttpPut("ApprovedOn/Service/{id}")]
        public async Task<IActionResult> AdminIsApprovedService( int id)
        {

            var Ads = await _db.Service.SingleOrDefaultAsync(x => x.Id == id);
            if (Ads == null)
            {
                return NotFound(new { Messages = $"Service Id {id} Not Exists Or IsApproved" });
            }

            if (Ads.IsApproved == false)
                Ads.IsApproved = true;


            var userAds = _db.UserService
                 .Where(x => x.ServiceId == id).Select(x =>new { x.User.FullName , x.User.Id});

            _db.Service.Update(Ads);
            _db.SaveChanges();


            return Ok(
                new
                {
                    Ads.Id,
                    userAds,
                    Ads.Title,
                    Ads.Type1,
                    Ads.Type2,
                    Ads.Type3,
                    Ads.Country,
                    Ads.City,
                    Ads.CreatedDate,
                    Ads.Description,
                    Ads.Price,
                    Ads.Image1,
                    Ads.Image2,
                    Ads.Image3,
                    Ads.Latitude,
                    Ads.Longitude,
                    Ads.PhoneNumber,
                    Ads.Warranty,
                    Ads.WhatsAppNumber,
                    Ads.CountDay,
                    Ads.CountPerson,
                    Ads.FromCountry,
                    Ads.ToCountry,
                    Ads.IsApproved,
                });

        }



        [HttpGet("GetAllService/Pending")]
        public async Task<IActionResult> GetAllServicePending()
        {
            var posts = await _db.Service
                 .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == false).Select(x => new
                 {
                    
                     UserId =x.User.Id,
                     x.User.FullName,
                     x.Service.Id,
                     x.Service.Title,
                     x.Service.Description,
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
                     x.Service.CountDay,
                     x.Service.ToCountry,
                     x.Service.Warranty,
                     x.Service.FromCountry,
                     x.Service.CountPerson,
                     x.Service.WhatsAppNumber,
                     x.Service.IsApproved
                 })).ToListAsync();
            return Ok(posts);
        }



        [HttpGet("GetOneService/Pending")]
        public async Task<IActionResult> GetOneServicePending(int id)
        {
            var posts = _db.Service.Where(x => x.Id == id).SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == false).Select(x => new
            {
                     UserId =x.User.Id,
                x.User.FullName,
                x.Service.Id,
                x.Service.Title,
                x.Service.Description,
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
                x.Service.CountDay,
                x.Service.ToCountry,
                x.Service.Warranty,
                x.Service.FromCountry,
                x.Service.CountPerson,
                x.Service.WhatsAppNumber,
                x.Service.IsApproved
            }));
            return Ok(posts);
        }



      






    }
}
