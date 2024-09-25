using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.ServicePackageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackageController : ControllerBase
    {


        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServicePackageController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // POST api/<PackageController>
        [HttpPost("AdminAddServicePackage")]
        public async Task<IActionResult> AddServicePackage([FromForm] DTOPackage dTOPackage)
        {
            ServicePackageModel packageModel = new()
            {
                Title = dTOPackage.Title,
                FeaturedAds = dTOPackage.FeaturedAds,
                price = dTOPackage.price,
                Sections = dTOPackage.Sections,
                ValidityDay = dTOPackage.ValidityDay,
            };
            await _db.ServicePackage.AddAsync(packageModel);
            _db.SaveChanges();

            ///// Send Notification for all user

            return Ok(new {packageModel.Id,
                packageModel.Title, packageModel.FeaturedAds,
                packageModel.price, packageModel.Sections,
                packageModel.ValidityDay });

        }


        // GET: api/<PackageController>
        [HttpGet("GetAllServicePackages")]
        public async Task<IActionResult> GetAllServicePackages()
        {
            var pack = await _db.ServicePackage.Select(x => new
            {
                x.Id,
                x.Title,
                x.ValidityDay,
                x.FeaturedAds,
                x.price,
                x.Sections,

            }).ToListAsync();
            return Ok(pack);
        }



        // GET api/<PackageController>/5
        [HttpGet("GetOneServicePackages")]
        public async Task<IActionResult> GetOneServicePackages(int id)
        {
            var pack = _db.ServicePackage.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.Title,
                x.ValidityDay,
                x.FeaturedAds,
                x.price,
                x.Sections,

            });
            return Ok(pack);
        }






        [HttpGet("GetUserServicePackages")]
        public async Task<IActionResult> GetUserServicePackages(string userId)
        {
            var posts = await _db.UserServicePackage.Where(x => x.UserId == userId)
              .SelectMany(P => P.Package.UserservicePackage.Select(x => new
              {
                  x.Package.Id,
                  x.Package.Title,
                  x.Package.ValidityDay,
                  x.Package.FeaturedAds,
                  x.Package.price,
                  x.Package.Sections,
              })).ToListAsync();
            return Ok(posts);
        }



        [HttpGet("GetAllUserFromServicePackage")]
        public async Task<IActionResult> GetAllUserFromServicePackage(int id)
        {
            var posts = await _db.UserServicePackage.Where(x => x.PackageId == id)
              .SelectMany(P => P.User.UserservicePackage.Select(x => new
              {
                  x.Package.Id,
                  x.Package.Title,
                  x.UserId,
                  x.User.UserName,
                  x.User.PhoneNumber,
                  x.User.Email,
                  x.User.CountAds,
                  x.User.CountService,
                  x.User.DateTime,
              })).ToListAsync();
            return Ok(posts);
        }



        [HttpGet("GetAllAdsForPackages")]
        public async Task<IActionResult> GetAllAdsForPackages(int packageId)
        {
            var posts = await _db.ServiceForPackage.Where(x => x.ServiceId == packageId)
              .SelectMany(P => P.Service.ServiceForPackage.Where(x=>x.Service.IsApproved == true).Select(x => new
              {
                  x.ServicePackage.Id,
                  x.ServicePackage.Title,
                  x.ServiceId,
                  x.Service.Description,
                  x.Service.Type1,
                  x.Service.Type2,
                  x.Service.Type3,
                  x.Service.Image1,
                  x.Service.Image2,
                  x.Service.Image3,
                  x.Service.Country,
                  x.Service.City,
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
                  x.Service.IsApproved,
              })).ToListAsync();
            return Ok(posts);
        }






        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpateService([FromForm] int id, [FromForm] DTOPackage dTOPackage)
        {

            var c = await _db.ServicePackage.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound(new { Messages = $"Package Id {id} Not Exists" });
            }

            if (dTOPackage.ValidityDay.ToString() == null)
                c.ValidityDay = c.ValidityDay;
            else
                c.ValidityDay = dTOPackage.ValidityDay;

            if (dTOPackage.Title == null)
                c.Title = c.Title;
            else
                c.Title = dTOPackage.Title;

            if (dTOPackage.Sections == null)
                c.Sections = c.Sections;
            else
                c.Sections = dTOPackage.Sections;


            if (dTOPackage.price.ToString() == null)
                c.price = c.price;
            else
                c.price = dTOPackage.price;


            if (dTOPackage.FeaturedAds.ToString() == null)
                c.FeaturedAds = c.FeaturedAds;
            else
                c.FeaturedAds = dTOPackage.FeaturedAds;



            _db.ServicePackage.Update(c);
            _db.SaveChanges();


            return Ok(new
            {
                c.Id,
                c.Title,
                c.FeaturedAds,
                c.price,
                c.Sections,
                c.ValidityDay
            });

        }





        [HttpPost("UserAddServicePakage")]
        public async Task<IActionResult> UserAddServicePakage(int packageId, string userId)
        {
            var userpack = await _db.UserServicePackage.SingleOrDefaultAsync(x => x.UserId == userId );

            if (userpack != null)
            {
                return Ok(new { Messages = "Already Subscribed" });
            }
            UserServicePackage userPackage = new()
            {
                PackageId = packageId,
                UserId = userId,
            };

            await _db.UserServicePackage.AddAsync(userPackage);

            var post = await _db.Users.SingleOrDefaultAsync(x => x.Id == userPackage.UserId);
            post.CountService = 0;

            _db.Users.Update(post);
            _db.SaveChanges();

            return Ok(new { Messages = "Congratulations, You Are Now A Subscriber" });

        }


    }


}

