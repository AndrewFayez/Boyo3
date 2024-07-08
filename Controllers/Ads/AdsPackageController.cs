using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BYO3WebAPI.Controllers.Ads
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsPackageController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdsPackageController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // POST api/<PackageController>
        [HttpPost("Admin/AddPackage")]
        public async Task<IActionResult> AddPackage([FromForm] DTOPackage dTOPackage)
        {
            AdsPackageModel packageModel = new()
            {
                Title = dTOPackage.Title,
                FeaturedAds = dTOPackage.FeaturedAds,
                price = dTOPackage.price,
                Sections = dTOPackage.Sections,
                ValidityDay = dTOPackage.ValidityDay,
            };
            await _db.Package.AddAsync(packageModel);
            _db.SaveChanges();

            ///// Send Notification for all user

            return Ok(new {packageModel.Id, packageModel.Title, packageModel.FeaturedAds,
                packageModel.price, packageModel.Sections, packageModel.ValidityDay });
        }


        // GET: api/<PackageController>
        [HttpGet("Admin/GetAllPackages")]
        public async Task<IActionResult> GetAllPackages()
        {
            var pack = await _db.Package.Select(x => new
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
        [HttpGet("Admin/GetOnePackages")]
        public async Task<IActionResult> GetOnePackages(int id)
        {
            var pack = _db.Package.Where(x => x.Id == id).Select(x => new
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



        [HttpGet("Admin/GetUserAdsPackages")]
        public async Task<IActionResult> GetUserPackages(string userId)
        {
            var posts = await _db.UserPackage.Where(x => x.UserId == userId)
              .SelectMany(P => P.Package.UserAdsPackage.Select(x => new
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


        [HttpGet("Admin/GetAllUserFromAdsPackage")]
        public async Task<IActionResult> GetAllUserFromAdsPackage(int id)
        {
            var posts = await _db.UserPackage.Where(x => x.PackageId == id)
              .SelectMany(P => P.User.UserPackage.Select(x => new
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






        [HttpGet("Admin/GetAllAdsForPackages")]
        public async Task<IActionResult> GetAllAdsForPackages(int packageId)
        {
            var posts = await _db.AdsForPackage.Where(x => x.PackageId == packageId)
              .SelectMany(P => P.Ads.AdsForPackages.Where(x => x.Ads.IsApproved == true).Select(x => new
              {
                  x.Package.Id,
                  x.Ads.Title,
                  x.AdsId,
                  x.Ads.Description,
                  x.Ads.PhoneNumber,
                  x.Ads.Latitude,
                  x.Ads.Longitude,
                  x.Ads.Price,
                  x.Ads.Country,
                  x.Ads.City,
                  x.Ads.CreatedDate,
                  x.Ads.Type3,
                  x.Ads.Type2,
                  x.Ads.Type1,
                  x.Ads.Type4,
                  x.Ads.Warranty,
                  x.Ads.WhatsAppNumber,
                  x.Ads.Image1,
                  x.Ads.Image2,
                  x.Ads.Image3,
                  x.Ads.AddOns,
                  x.Ads.AdsType
                ,
                  x.Ads.Size,
                  x.Ads.AirConditionCount,
                  x.Ads.AirConditionSize,
                  x.Ads.AirConditionType,
                  x.Ads.ColorIn,
                  x.Ads.ColorOut,
                  x.Ads.Cylinders
                ,
                  x.Ads.Faults,
                  x.Ads.Height,
                  x.Ads.GeneratorType,
                  x.Ads.Kilometer,
                  x.Ads.NormalOrSaylant,
                  x.Ads.NumberOfParson,
                  x.Ads.PublicStatus
                ,
                  x.Ads.Security,
                  x.Ads.Specifications,
                  x.Ads.YearMake,
                  x.Ads.IsApproved
              })).ToListAsync();
            return Ok(posts);
        }







        [HttpPut("Admin/UpdatePackage")]
        public async Task<IActionResult> UpatePost([FromForm] int id, [FromForm] DTOPackage dTOPackage)
        {

            var c = await _db.Package.SingleOrDefaultAsync(x => x.Id == id);
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



            _db.Package.Update(c);
            _db.SaveChanges();


            return Ok(new {c.Id, c.Title, c.ValidityDay, c.FeaturedAds , c.price , c.Sections   });

        }


        [HttpPost("Admin/UserAddPakage")]
        public async Task<IActionResult> UserAddPakage(int packageId, string userId)
        {
            var userpack = await _db.UserPackage.SingleOrDefaultAsync(x => x.UserId == userId );
            //&& packageId == x.PackageId
            if (userpack != null)
            {
                return Ok(new { Messages = "Already Subscribed" });
            }
            UserAdsPackage userPackage = new()
            {
                PackageId = packageId,
                UserId = userId,
            };

            await _db.UserPackage.AddAsync(userPackage);
            _db.SaveChanges();

            var post = await _db.Users.SingleOrDefaultAsync(x => x.Id == userPackage.UserId);
            post.CountAds = 0;

            _db.Users.Update(post);
            _db.SaveChanges();

            return Ok(new { Messages = "Congratulations, You Are Now A Subscriber" });

        }


    }
}
