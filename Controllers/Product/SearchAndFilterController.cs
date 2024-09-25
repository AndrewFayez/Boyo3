using BYO3WebAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAndFilterController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SearchAndFilterController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("SearchInProductUsingName")]
        public async Task<IActionResult> SearchInProduct(string Name)
        {
            
                var result = await _db.ProductModel.Where(x => x.ProductNameEnglish.ToLower().Contains(Name.ToLower())
                || x.ProductNameArabic.ToLower().Contains(Name.ToLower()))
                   .Select(x => new
                   {
                       x.Id,
                       x.ProductNameArabic,
                       x.ProductNameEnglish,
                       x.price,
                       x.Content,
                       x.Describtion,
                       x.CreatedDate,
                       x.Image1,
                       x.Image2,
                       x.Image3,
                       x.quantity
                   }).ToListAsync();
                return Ok(result);

        }

        [HttpGet("SearchInProductUsingPrice")]
        public async Task<IActionResult> SearchInProductUsingPrice(decimal? minPrice, decimal? maxPrice)
        {
            var prices =await _db.ProductModel
            .Where(x => x.price >= minPrice && x.price <= maxPrice)
              .Select(x => new
              {
                  x.Id,
                  x.ProductNameArabic,
                  x.ProductNameEnglish,
                  x.price,
                  x.Content,
                  x.Describtion,
                  x.CreatedDate,
                  x.Image1,
                  x.Image2,
                  x.Image3,
                  x.quantity
              }).ToListAsync();

            return Ok(prices);
        }



    }
}
