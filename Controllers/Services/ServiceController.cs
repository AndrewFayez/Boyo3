using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using BYO3WebAPI.Models.DataModels.ServicePackageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly IWebHostEnvironment _host;
        private readonly ApplicationDbContext _db;

        public ServiceController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }

        // POST api/<AdsController>
        [HttpPost("AddService")]
        public async Task<IActionResult> Post([FromForm] DTOService dTOAds, string userId)
        {
            var AdsCount = _db.Users.Where(x => x.Id == userId).Select(x => x.CountService).FirstOrDefault();
            var packagenumber = _db.UserServicePackage.Where(x => x.UserId == userId).Select(x => x.Package.FeaturedAds).FirstOrDefault();

            var package = await _db.UserServicePackage.SingleOrDefaultAsync(x => x.UserId == userId);

            var userpackagetype = _db.UserPackage.Where(x => x.UserId == userId).Select(x => x.Package.Title).FirstOrDefault();

            if (package == null)
            {
                return BadRequest(new { Messages = "Please, You Must Be A Subscriber To The Package" });
            }


            if (AdsCount >= packagenumber)
            {
                _db.Remove(package);
                _db.SaveChanges();
                return BadRequest(new { Messages = "Please Renew The Package Or Subscribe To A New Package" });
            }


            if (dTOAds.Image1 == null || dTOAds.Image1.Length == 0)
            {
                return BadRequest(new { Messages = "No File Selected." });
            }
            string randem1 = Guid.NewGuid().ToString();
            string path1 = Path.Combine("StaticFile/Images/", $"{randem1}_{dTOAds.Image1.FileName}");
            string fullPath1 = Path.Combine(_host.ContentRootPath.ToString(), path1);

            using (var stream = new FileStream(fullPath1, FileMode.Create))
            {
                await dTOAds.Image1.CopyToAsync(stream);
            }


            if (dTOAds.Image2 == null || dTOAds.Image2.Length == 0)
            {
                return BadRequest(new { Messages = "No File Selected." });
            }

            string randem2 = Guid.NewGuid().ToString();
            string path2 = Path.Combine("StaticFile/Images/", $"{randem2}_{dTOAds.Image2.FileName}");
            string fullPath2 = Path.Combine(_host.ContentRootPath.ToString(), path2);

            using (var stream = new FileStream(fullPath2, FileMode.Create))
            {
                await dTOAds.Image2.CopyToAsync(stream);
            }

            if (dTOAds.Image3 == null || dTOAds.Image3.Length == 0)
            {
                return BadRequest(new { Messages = "No File Selected." });
            }

            string randem3 = Guid.NewGuid().ToString();
            string path3 = Path.Combine("StaticFile/Images/", $"{randem3}_{dTOAds.Image3.FileName}");
            string fullPath3 = Path.Combine(_host.ContentRootPath.ToString(), path3);

            using (var stream = new FileStream(fullPath3, FileMode.Create))
            {
                await dTOAds.Image3.CopyToAsync(stream);
            }



            ServiceModels Ads = new()
            {
                Title = dTOAds.Title,
                Type1 = dTOAds.Type1,
                Type2 = dTOAds.Type2,
                Type3 = dTOAds.Type3,
                Country = dTOAds.Country,
                City = dTOAds.City,
                CreatedDate = DateTime.Now,
                Description = dTOAds.Description,
                Price = dTOAds.Price,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                Latitude = dTOAds.Latitude,
                Longitude = dTOAds.Longitude,
                PhoneNumber = dTOAds.PhoneNumber,
                Warranty = dTOAds.Warranty,
                WhatsAppNumber = dTOAds.WhatsAppNumber,
                CountDay = dTOAds.CountDay,
                CountPerson = dTOAds.CountPerson,
                FromCountry = dTOAds.FromCountry,
                ToCountry = dTOAds.ToCountry,
                IsApproved = false,

            };
            await _db.Service.AddAsync(Ads);
            _db.SaveChanges();

            UserService postUser = new UserService { UserId = userId, ServiceId = Ads.Id };
            _db.UserService.Add(postUser);
            _db.SaveChanges();


            ServiceForPackage Adspackage = new ServiceForPackage { ServicePackageId = package.PackageId, ServiceId = Ads.Id };
            _db.ServiceForPackage.Add(Adspackage);
            _db.SaveChanges();


            var countAds = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            countAds.CountService = countAds.CountService + 1;
            _db.Users.Update(countAds);

            _db.SaveChanges();

            return Ok(new {
               UserId = countAds.Id,
                countAds.FullName,
                Ads.Id,
                Ads.Title, 
                Ads.Type1,
                Ads.Type2 ,
                Ads.Type3 ,
                Ads.Country,
                Ads.City,
                Ads.CreatedDate,
                Ads.Description ,
                Ads.Price ,
                Ads.Image1 ,
                Ads.Image2,
                Ads.Image3,
                Ads.Latitude ,
                Ads.Longitude,
                Ads.PhoneNumber,
                Ads.Warranty ,
                Ads.WhatsAppNumber, 
                Ads.CountDay,
                Ads.CountPerson, 
                Ads.FromCountry ,
                Ads.ToCountry ,
                Ads.IsApproved ,
            });
        }




        // GET: api/<AdsController>
        [HttpGet("GetAllServiceForUser")]
        public async Task<IActionResult> GetAllServiceForUser(string userId)
        {
            var Ads = await _db.UserService.Where(x => x.UserId == userId && x.Service.IsApproved == true)
                .Select(x => 
                new {
                    UserId = x.User.Id,
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
                    x.Service.IsApproved
                }
                ).ToListAsync();
            return Ok(Ads);
        }


        [HttpGet("GetAllServiceIsApproved")]
        public async Task<IActionResult> GetAllServiceIsApproved()
        {
            var posts = await _db.Service.Where(x=>x.IsApproved == true)
                 .SelectMany(x => x.UserService.Select(x => new
                 {
                     UserId = x.User.Id,
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




        [HttpGet("GetAllServicePending")]
        public async Task<IActionResult> GetAllServicePending()
        {
            var posts = await _db.Service.Where(x => x.IsApproved == false)
                 .SelectMany(x => x.UserService.Select(x => new
                 {
                     UserId = x.User.Id,
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




        // GET api/<AdsController>/5
        [HttpGet("GetOneServiceIsApproved")]
        public async Task<IActionResult> GetOneServiceIsApproved(int id)
        {
            var posts = await _db.Service.Where(x =>x.Id==id && x.IsApproved == true)
                .SelectMany(x => x.UserService.Select(x => new
                {
                    UserId = x.User.Id,
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

        [HttpGet("GetOneServicePending")]
        public async Task<IActionResult> GetOneServicePending(int id)
        {
            var posts = await _db.Service.Where(x =>x.Id==id && x.IsApproved == false)
      .SelectMany(x => x.UserService.Select(x => new
      {
          UserId = x.User.Id,
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


        // DELETE api/<AdsController>/5
        [HttpDelete("DeleteService/{id}/{userId}")]
        public async Task<IActionResult> Delete(int id ,string userId)
        {
            var ads = await _db.Service.SingleOrDefaultAsync(x => x.Id == id);
            var adspackage = await _db.ServiceForPackage.SingleOrDefaultAsync(x => x.ServiceId == ads.Id);
            var userAds = await _db.UserService.SingleOrDefaultAsync(x => x.ServiceId == id && x.UserId == userId);
            if (ads == null)
            {
                return BadRequest(new { Messages = "This Service Is Not Found" });

            }
            if (userAds == null)
            {
                return BadRequest(new { Messages = "This Service Is Not Found" });

            }
            _db.UserService.Remove(userAds);
            _db.ServiceForPackage.Remove(adspackage);
            _db.Service.Remove(ads);
            _db.SaveChanges();
            return Ok(new { ads.Id, ads.Title, ads.Description, ads.PhoneNumber });
        }
    }
}

