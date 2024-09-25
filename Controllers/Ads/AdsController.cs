using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BYO3WebAPI.Controllers.Ads
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _host;

        public AdsController(ApplicationDbContext db,  IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }

        // POST api/<AdsController>
        [HttpPost("AddCaravanAds")]
        public async Task<IActionResult> Caravan([FromForm] DTOAds dTOAds, string userId)
        {
            var AdsCount = _db.Users.Where(x => x.Id == userId).Select(x => x.CountAds).FirstOrDefault();
            var packagenumber = _db.UserPackage.Where(x => x.UserId == userId).Select(x => x.Package.FeaturedAds).FirstOrDefault();

            var package = await _db.UserPackage.SingleOrDefaultAsync(x => x.UserId == userId);

            var userpackagetype =  _db.UserPackage.Where(x=>x.UserId  == userId ).Select(x=>x.Package.Title).FirstOrDefault();

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
            string path1 = Path.Combine("StaticFile/Images/", $"{randem1}_{dTOAds.Image1.FileName}" );
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





            AdsModel Ads = new()
            {
                Title = dTOAds.Title,
                Type1 = dTOAds.Type1,
                Type2 = dTOAds.Type2,
                Type3 = dTOAds.Type3,
                Type4 = dTOAds.Type4,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                Country = dTOAds.Country,
                City = dTOAds.City,
                CreatedDate = DateTime.Now,
                Description = dTOAds.Description,
                Price = dTOAds.Price,
                Latitude = dTOAds.Latitude,
                Longitude = dTOAds.Longitude,
                PhoneNumber = dTOAds.PhoneNumber,
                Warranty = dTOAds.Warranty,
                WhatsAppNumber = dTOAds.WhatsAppNumber,
                AddOns = dTOAds.AddOns,
                AdsType = userpackagetype,
                AirConditionCount = dTOAds.AirConditionCount,
                AirConditionSize = dTOAds.AirConditionSize,
                AirConditionType = dTOAds.AirConditionType,
                ColorIn = dTOAds.ColorIn,
                ColorOut = dTOAds.ColorOut,
                Cylinders = dTOAds.Cylinders,
                Faults = dTOAds.Faults,
                GeneratorType = dTOAds.GeneratorType,
                Height = dTOAds.Height,
                Kilometer = dTOAds.Kilometer,
                NormalOrSaylant = dTOAds.NormalOrSaylant,
                NumberOfParson = dTOAds.NumberOfParson,
                PublicStatus = dTOAds.PublicStatus,
                Security = dTOAds.Security,
                Size = dTOAds.Size,
                Specifications = dTOAds.Specifications,
                YearMake = dTOAds.YearMake,
                IsApproved = false,
               
            };
            await _db.Ads.AddAsync(Ads);
            _db.SaveChanges();

          
            UserAds postUser = new UserAds { UserId = userId, AdsId = Ads.Id };
            _db.UserAds.Add(postUser);
            _db.SaveChanges();

            AdsForPackage Adspackage = new AdsForPackage { PackageId = package.PackageId, AdsId = Ads.Id };
            _db.AdsForPackage.Add(Adspackage);
            _db.SaveChanges();


            var countAds = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            countAds.CountAds = countAds.CountAds + 1;
            _db.Users.Update(countAds);

            _db.SaveChanges();

            return Ok(new {
                Ads.Id ,
                countAds.FullName,
                UserId =countAds.Id,
                Ads.Title ,
                Ads.Description , 
                Ads.PhoneNumber ,
                Ads.Latitude ,
                Ads.Longitude ,
                Ads.Price ,
                Ads.Country ,
                Ads.City,
                Ads.CreatedDate , 
                Ads.Type3 ,
                Ads.Type2 , 
                Ads.Type1 ,
                Ads.Type4 ,
                Ads.Warranty , 
                Ads.WhatsAppNumber ,
                Ads.Image1 ,
                Ads.Image2 ,
                Ads.Image3 ,
                Ads.AddOns,
                Ads.AdsType
                ,Ads.Size ,
                Ads.AirConditionCount,
                Ads.AirConditionSize,
                Ads.AirConditionType,
                Ads.ColorIn,
                Ads.ColorOut,
                Ads.Cylinders
                ,Ads.Faults,
                Ads.Height,
                Ads.GeneratorType,
                Ads.Kilometer,
                Ads.NormalOrSaylant,
                Ads.NumberOfParson,
                Ads.PublicStatus
                ,Ads.Security ,
                Ads.Specifications,
                Ads.YearMake,
                Ads.IsApproved,
            });
        }



        [HttpPost("AddCarAds")]
        public async Task<IActionResult> AdsCar([FromForm] DTOAds dTOAds, string userId)
        {
            var AdsCount = _db.Users.Where(x => x.Id == userId).Select(x => x.CountAds).FirstOrDefault();
            var packagenumber = _db.UserPackage.Where(x => x.UserId == userId).Select(x => x.Package.FeaturedAds).FirstOrDefault();

            var package = await _db.UserPackage.SingleOrDefaultAsync(x => x.UserId == userId);

            if (package == null)
            {
                return BadRequest(new { Messages = "Please, You Must Be A Subscriber To The Package" });
            }


            if (AdsCount >= packagenumber)
            {

                _db.Remove(package);
                _db.SaveChanges();
                return BadRequest(new { Messages="Please Renew The Package Or Subscribe To A New Package" });
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

            AdsModel Ads = new()
            {
                Title = dTOAds.Title,
                Type1 = dTOAds.Type1,
                Type2 = dTOAds.Type2,
                Type3 = dTOAds.Type3,
                Type4 = dTOAds.Type4,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                Country = dTOAds.Country,
                City = dTOAds.City,
                CreatedDate = DateTime.Now,
                Description = dTOAds.Description,
                Price = dTOAds.Price,
                Latitude = dTOAds.Latitude,
                Longitude = dTOAds.Longitude,
                PhoneNumber = dTOAds.PhoneNumber,
                Warranty = dTOAds.Warranty,
                WhatsAppNumber = dTOAds.WhatsAppNumber,
                AddOns = dTOAds.AddOns,
                AdsType = dTOAds.AdsType,
                ColorIn = dTOAds.ColorIn,
                ColorOut = dTOAds.ColorOut,
                Cylinders = dTOAds.Cylinders,
                PublicStatus = dTOAds.PublicStatus,
                Security = dTOAds.Security,
                Specifications = dTOAds.Specifications,
                YearMake = dTOAds.YearMake,
                Kilometer = dTOAds.Kilometer,
                AirConditionCount = "NoData",
                AirConditionSize = "NoData",
                AirConditionType = "NoData",
                Faults = "NoData",
                GeneratorType = "NoData",
                Height = 0,
                NormalOrSaylant = "NoData",
                NumberOfParson = 0,
                Size = "NoData",
                IsApproved= false,

            };
            await _db.Ads.AddAsync(Ads);
            _db.SaveChanges();


            UserAds postUser = new UserAds { UserId = userId, AdsId = Ads.Id };
            _db.UserAds.Add(postUser);
            _db.SaveChanges();

            AdsForPackage Adspackage = new AdsForPackage { PackageId = package.PackageId, AdsId = Ads.Id };
            _db.AdsForPackage.Add(Adspackage);
            _db.SaveChanges();


            var countAds = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            countAds.CountAds = countAds.CountAds + 1;
            _db.Users.Update(countAds);

            _db.SaveChanges();

            return Ok(new
            {
                Ads.Id,
                countAds.FullName,
                UserId = countAds.Id,
                Ads.Title,
                Ads.Description,
                Ads.PhoneNumber,
                Ads.Latitude,
                Ads.Longitude,
                Ads.Price,
                Ads.Country,
                Ads.City,
                Ads.CreatedDate,
                Ads.Type3,
                Ads.Type2,
                Ads.Type1,
                Ads.Type4,
                Ads.Warranty,
                Ads.WhatsAppNumber,
                Ads.Image1,
                Ads.Image2,
                Ads.Image3,
                Ads.AddOns,
                Ads.AdsType
                ,
                Ads.Size,
                Ads.AirConditionCount,
                Ads.AirConditionSize,
                Ads.AirConditionType,
                Ads.ColorIn,
                Ads.ColorOut,
                Ads.Cylinders
                ,
                Ads.Faults,
                Ads.Height,
                Ads.GeneratorType,
                Ads.Kilometer,
                Ads.NormalOrSaylant,
                Ads.NumberOfParson,
                Ads.PublicStatus
                ,
                Ads.Security,
                Ads.Specifications,
                Ads.YearMake,
                Ads.IsApproved,
            });
        }



        [HttpPost("AddMotorAds")]
        public async Task<IActionResult> AddMotorAds([FromForm] DTOAds dTOAds, string userId)
        {
            var AdsCount = _db.Users.Where(x => x.Id == userId).Select(x => x.CountAds).FirstOrDefault();
            var packagenumber = _db.UserPackage.Where(x => x.UserId == userId).Select(x => x.Package.FeaturedAds).FirstOrDefault();

            var package = await _db.UserPackage.SingleOrDefaultAsync(x => x.UserId == userId);

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

            AdsModel Ads = new()
            {
                Title = dTOAds.Title,
                Type1 = dTOAds.Type1,
                Type2 = dTOAds.Type2,
                Type3 = dTOAds.Type3,
                Type4 = dTOAds.Type4,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                Country = dTOAds.Country,
                City = dTOAds.City,
                CreatedDate = DateTime.Now,
                Description = dTOAds.Description,
                Price = dTOAds.Price,
                Latitude = dTOAds.Latitude,
                Longitude = dTOAds.Longitude,
                PhoneNumber = dTOAds.PhoneNumber,
                Warranty = dTOAds.Warranty,
                WhatsAppNumber = dTOAds.WhatsAppNumber,
                AddOns = dTOAds.AddOns,
                AdsType = dTOAds.AdsType,
                ColorOut = dTOAds.ColorOut,
                Cylinders = dTOAds.Cylinders,
                Kilometer = dTOAds.Kilometer,
                PublicStatus = dTOAds.PublicStatus,
                Security = dTOAds.Security,
                Specifications = dTOAds.Specifications,
                YearMake = dTOAds.YearMake,
                AirConditionCount = "NoData",
                AirConditionSize = "NoData",
                AirConditionType = "NoData",
                ColorIn = "NoData",
                Faults = "NoData",
                GeneratorType = "NoData",
                Height = 0,
                NormalOrSaylant = "NoData",
                NumberOfParson = 0,
                Size = "NoData",
                IsApproved = false,
            };
            await _db.Ads.AddAsync(Ads);
            _db.SaveChanges();


            UserAds postUser = new UserAds { UserId = userId, AdsId = Ads.Id };
            _db.UserAds.Add(postUser);
            _db.SaveChanges();


            AdsForPackage Adspackage = new AdsForPackage { PackageId = package.PackageId, AdsId = Ads.Id };
            _db.AdsForPackage.Add(Adspackage);
            _db.SaveChanges();


            var countAds = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            countAds.CountAds = countAds.CountAds + 1;
            _db.Users.Update(countAds);

            _db.SaveChanges();

            return Ok(new
            {
                Ads.Id,
                countAds.FullName,
                UserId =countAds.Id,
                Ads.Title,
                Ads.Description,
                Ads.PhoneNumber,
                Ads.Latitude,
                Ads.Longitude,
                Ads.Price,
                Ads.Country,
                Ads.City,
                Ads.CreatedDate,
                Ads.Type3,
                Ads.Type2,
                Ads.Type1,
                Ads.Type4,
                Ads.Warranty,
                Ads.WhatsAppNumber,
                Ads.Image1,
                Ads.Image2,
                Ads.Image3,
                Ads.AddOns,
                Ads.AdsType
                ,
                Ads.Size,
                Ads.AirConditionCount,
                Ads.AirConditionSize,
                Ads.AirConditionType,
                Ads.ColorIn,
                Ads.ColorOut,
                Ads.Cylinders
                ,
                Ads.Faults,
                Ads.Height,
                Ads.GeneratorType,
                Ads.Kilometer,
                Ads.NormalOrSaylant,
                Ads.NumberOfParson,
                Ads.PublicStatus
                ,
                Ads.Security,
                Ads.Specifications,
                Ads.YearMake,
                Ads.IsApproved,
            });
        }



        [HttpPost("AddToolsAds")]
        public async Task<IActionResult> AddToolsAds([FromForm] DTOAds dTOAds, string userId)
        {
            var AdsCount = _db.Users.Where(x => x.Id == userId).Select(x => x.CountAds).FirstOrDefault();
            var packagenumber = _db.UserPackage.Where(x => x.UserId == userId).Select(x => x.Package.FeaturedAds).FirstOrDefault();

            var package = await _db.UserPackage.SingleOrDefaultAsync(x => x.UserId == userId);

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




            AdsModel Ads = new()
            {
                Title = dTOAds.Title,
                Type1 = dTOAds.Type1,
                Type2 = dTOAds.Type2,
                Type3 = dTOAds.Type3,
                Type4 = dTOAds.Type4,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                Country = dTOAds.Country,
                City = dTOAds.City,
                CreatedDate = DateTime.Now,
                Description = dTOAds.Description,
                Price = dTOAds.Price,
                Latitude = dTOAds.Latitude,
                Longitude = dTOAds.Longitude,
                PhoneNumber = dTOAds.PhoneNumber,
                Warranty = dTOAds.Warranty,
                WhatsAppNumber = dTOAds.WhatsAppNumber,
                AddOns = dTOAds.AddOns,
                AdsType = dTOAds.AdsType,
                PublicStatus = dTOAds.PublicStatus,
                Security = dTOAds.Security,
                Specifications = dTOAds.Specifications,
                YearMake = dTOAds.YearMake,
                AirConditionCount = "NoData",
                AirConditionSize = "NoData",
                AirConditionType = "NoData",
                ColorIn = "NoData",
                ColorOut = "NoData",
                Cylinders = 0,
                Faults = "NoData",
                GeneratorType = "NoData",
                Height = 0,
                Kilometer = 0,
                NormalOrSaylant = "NoData",
                NumberOfParson = 0,
                Size = "NoData",
                IsApproved=false,
            };
            await _db.Ads.AddAsync(Ads);
            _db.SaveChanges();


            UserAds postUser = new UserAds { UserId = userId, AdsId = Ads.Id };
            _db.UserAds.Add(postUser);
            _db.SaveChanges();

            AdsForPackage Adspackage = new AdsForPackage { PackageId = package.PackageId, AdsId = Ads.Id };
            _db.AdsForPackage.Add(Adspackage);
            _db.SaveChanges();


            var countAds = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            countAds.CountAds = countAds.CountAds + 1;
            _db.Users.Update(countAds);

            _db.SaveChanges();

            return Ok(new
            {
                Ads.Id,
                countAds.FullName,
                UserId =countAds.Id,
                Ads.Title,
                Ads.Description,
                Ads.PhoneNumber,
                Ads.Latitude,
                Ads.Longitude,
                Ads.Price,
                Ads.Country,
                Ads.City,
                Ads.CreatedDate,
                Ads.Type3,
                Ads.Type2,
                Ads.Type1,
                Ads.Type4,
                Ads.Warranty,
                Ads.WhatsAppNumber,
                Ads.Image1,
                Ads.Image2,
                Ads.Image3,
                Ads.AddOns,
                Ads.AdsType
                ,
                Ads.Size,
                Ads.AirConditionCount,
                Ads.AirConditionSize,
                Ads.AirConditionType,
                Ads.ColorIn,
                Ads.ColorOut,
                Ads.Cylinders
                ,
                Ads.Faults,
                Ads.Height,
                Ads.GeneratorType,
                Ads.Kilometer,
                Ads.NormalOrSaylant,
                Ads.NumberOfParson,
                Ads.PublicStatus
                ,
                Ads.Security,
                Ads.Specifications,
                Ads.YearMake,
                Ads.IsApproved,
            });
        }




        // GET: api/<AdsController>
        [HttpGet("GetAllAdsForUserApproved")]
        public async Task<IActionResult> GetAllAdsForUser(string userId)
        {
            var posts = await _db.UserAds.Where(x => x.UserId == userId)
                .SelectMany(P => P.Ads.UserAds.Where(x=> x.Ads.IsApproved == true).Select(x => new
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
            return Ok(posts);
        }


        [HttpGet("GetAllAdsForUserPending")]
        public async Task<IActionResult> GetAllAdsForUserPending(string userId)
        {
            var posts = await _db.UserAds.Where(x => x.UserId == userId)
                .SelectMany(P => P.Ads.UserAds.Where(x => x.Ads.IsApproved == false).Select(x => new
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
            return Ok(posts);
        }



        [HttpGet("GetAllAdsApproved")]
        public async Task<IActionResult> GetAllAdsApproved()
        {
            var posts = await _db.Ads
                 .SelectMany(x => x.UserAds.Where(x=>x.Ads.IsApproved == true).Select(x => new
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
            return Ok(posts);
        }




     

        // GET api/<AdsController>/5
        [HttpGet("GetOneAdsApproved")]
        public async Task<IActionResult> GetOneAds(int id)
        {
            var posts = _db.Ads.Where(x => x.Id == id).SelectMany(x => x.UserAds.Where(x => x.Ads.IsApproved == true).Select(x => new
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
            }));
            return  Ok(posts);
        }


        // DELETE api/<AdsController>/5
        [HttpDelete("DeleteAds/{id}/{userId}")]
        public async Task<IActionResult> Delete(int id , string userId)
        {
            var ads = await _db.Ads.SingleOrDefaultAsync(x => x.Id == id);
            var adspackage = await _db.AdsForPackage.SingleOrDefaultAsync(x => x.AdsId == ads.Id);
            var userAds =await  _db.UserAds.SingleOrDefaultAsync(x=>x.AdsId == id && x.UserId== userId);
            if (ads == null)
            {
                return BadRequest(new { Messages = "This Ads Is Not Found" });

            }
            if (userAds == null)
            {
                return BadRequest(new { Messages = "This User Is Not Found" });

            }
            _db.UserAds.Remove(userAds);
            _db.AdsForPackage.Remove(adspackage);
            _db.Ads.Remove(ads);
            _db.SaveChanges();
            return Ok(new {ads.Id , ads.Title , ads.Description , ads.PhoneNumber});
        }
    }
}
