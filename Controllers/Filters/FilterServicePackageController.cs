using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Filters
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterServicePackageController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FilterServicePackageController(ApplicationDbContext db)
        {
            _db = db;
        }




        [HttpGet("GetAllServiceGoldCamping")]
        public async Task<IActionResult> GetAllServiceGoldCamping()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved==true).Select(x => new
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
                }).Where(x => x.Type1 == "Camping");

                return Ok(ads);

            }

            return Ok();
        }




        [HttpGet("GetAllServiceGoldMaintenance")]
        public async Task<IActionResult> GetAllServiceGoldMaintenance()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Maintenance");

                return Ok(ads);

            }

            return Ok();
        }





        [HttpGet("GetAllServiceGoldRent")]
        public async Task<IActionResult> GetAllServiceGoldRent()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Rent");

                return Ok(ads);

            }

            return Ok();
        }




        [HttpGet("GetAllServiceGoldTransfer")]
        public async Task<IActionResult> GetAllServiceGoldTransfer()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Transfer");

                return Ok(ads);

            }

            return Ok();
        }







        [HttpGet("GetAllServiceGoldLaundry")]
        public async Task<IActionResult> GetAllServiceGoldLaundry()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Washing");

                return Ok(ads);

            }

            return Ok();
        }





        [HttpGet("GetAllServiceGoldWasteDisposal")]
        public async Task<IActionResult> GetAllServiceGoldWasteDisposal()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Waste Dispol");

                return Ok(ads);

            }

            return Ok();
        }




        [HttpGet("GetAllServiceGoldWaterRefill")]
        public async Task<IActionResult> GetAllServiceGoldWaterRefill()
        {
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            foreach (var item in pac)
            {
                var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
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
                }).Where(x => x.Type1 == "Water Filling");

                return Ok(ads);

            }

            return Ok();
        }



        [HttpGet("GetAllServiceGold")]
        public async Task<IActionResult> GetAllServiceGold()
        {
            //var pac = await _db.ServicePackage.Where(x => x.Title == "Gold").SelectMany(x => x.UserservicePackage.Select(x => new { x.User.Id })).ToListAsync();

            //foreach (var item in pac)
            //{
            //    var ads = _db.UserService.Where(x => x.UserId == item.Id && x.Service.IsApproved == true).Select(x => new
            var pac = await _db.ServicePackage.Where(x => x.Title == "Gold")
                .SelectMany(x => x.UserservicePackage.
                SelectMany(x => x.User.UserService.Where(x =>  x.Service.IsApproved == true)
                .Select(
                    x => new
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
                    }
              ))).ToListAsync();

            return Ok(pac);

            //}

            //return Ok();
        }




    }
}
