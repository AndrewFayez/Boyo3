using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FilterServiceController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet("GetAllServiceType1")]
        public async Task<IActionResult> GetAllServiceType1(string service)
        {
            var post =await _db.Service.Where(x => x.Type1 == service)
               .SelectMany(x => x.UserService.Where(x=>x.Service.IsApproved==true).Select(x => new
               {
                    UserId= x.User.Id,
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
            return  Ok(post);
        }




        [HttpGet("GetAllServiceType2")]
        public async Task<IActionResult> GetAllServiceType2(string service)
        {
            var post =await _db.Service.Where(x => x.Type2 == service)
               .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(post);
        }




        [HttpGet("GetAllServiceType3")]
        public async Task<IActionResult> GetAllServiceType3(string service)
        {
            var post =await _db.Service.Where(x => x.Type3 == service)
               .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return Ok(post);
        }






        [HttpGet("GetAllServiceType1AndType2")]
        public async Task<IActionResult> GetAllServiceType1And2(string serv1, string serv2)
        {
            var servic =await _db.Service.Where(x => x.Type1 == serv1 && x.Type2 == serv2)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(servic);
        }



        [HttpGet("GetAllServiceType2AndType3")]
        public async Task<IActionResult> GetAllServiceType2And3(string serv3, string serv2)
        {
            var servic =await _db.Service.Where(x => x.Type2 == serv3 && x.Type3 == serv2)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(servic);
        }




        [HttpGet("GetAllServiceType1AndType3")]
        public async Task<IActionResult> GetAllAdsType1And3(string serv1, string serv2)
        {
            var servic =await _db.Service.Where(x => x.Type1 == serv1 && x.Type3 == serv2)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(servic);
        }


     

        [HttpGet("GetAllServiceType1AndCountry")]
        public async Task<IActionResult> GetAllAdsType1AndCountry(string serv1, string Country)
        {
            var caravan =await _db.Service.Where(x => x.Type1 == serv1 && x.Country == Country)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(caravan);
        }




        [HttpGet("GetAllServiceType1And2AndCountry")]
        public async Task<IActionResult> GetAllAdsType1And2AndCountry(string serv1, string serv2, string Country)
        {
            var servic = await _db.Service.Where(x => x.Type1 == serv1 && x.Type2 == serv2 && x.Country == Country)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(servic);
        }





        [HttpGet("GetAllServiceType1AndType2And3")]
        public async Task<IActionResult> GetAllAdsType1AndType2And3(string serv1, string serv2, string serv3)
        {
            var servic = await _db.Service.Where(x => x.Type1 == serv1 && x.Type2 == serv2 && x.Type3 == serv3)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return  Ok(servic);
        }



        [HttpGet("GetAllserviceCountryAndCity")]
        public async Task<IActionResult> GetAllserviceCountryAndCity(string city, string Country)
        {
            var caravan = await _db.Service.Where(x => x.City == city && x.Country == Country)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return Ok(caravan);
        }



        [HttpGet("GetAllServiceType1And2AndCity")]
        public async Task<IActionResult> GetAllServiceType1And2AndCity(string serv1, string serv2, string city)
        {
            var servic = await _db.Service.Where(x => x.Type1 == serv1 && x.Type2 == serv2 && x.City == city)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return Ok(servic);
        }




        [HttpGet("GetAllServiceType1AndCity")]
        public async Task<IActionResult> GetAllServiceType1AndCity(string serv1,  string city)
        {
            var servic = await _db.Service.Where(x => x.Type1 == serv1 &&  x.City == city)
                .SelectMany(x => x.UserService.Where(x => x.Service.IsApproved == true).Select(x => new
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
            return Ok(servic);
        }


    }
}
