using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BYO3WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _host;


        public ProductController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }

        [HttpPost("AdminAddProduct")]
        public async Task<IActionResult> AddPackage([FromForm] DTOProduct dTOProduct, string userId)
        {

            if (dTOProduct.Image1 == null || dTOProduct.Image1.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }

            string path1 = Path.Combine("StaticFile/Images/", dTOProduct.Image1.FileName);
            string fullPath1 = Path.Combine(_host.ContentRootPath.ToString(), path1);

            using (var stream = new FileStream(fullPath1, FileMode.Create))
            {
                await dTOProduct.Image1.CopyToAsync(stream);
            }


            if (dTOProduct.Image2 == null || dTOProduct.Image2.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }


            string path2 = Path.Combine("StaticFile/Images/", dTOProduct.Image2.FileName);
            string fullPath2 = Path.Combine(_host.ContentRootPath.ToString(), path2);

            using (var stream = new FileStream(fullPath2, FileMode.Create))
            {
                await dTOProduct.Image2.CopyToAsync(stream);
            }


            if (dTOProduct.Image3 == null || dTOProduct.Image3.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }


            string path3 = Path.Combine("StaticFile/Images/", dTOProduct.Image3.FileName);
            string fullPath3 = Path.Combine(_host.ContentRootPath.ToString(), path3);

            using (var stream = new FileStream(fullPath3, FileMode.Create))
            {
                await dTOProduct.Image3.CopyToAsync(stream);
            }


            ProductModel productModel = new()
            {
                ProductNameArabic = dTOProduct.ProductNameArabic,
                ProductNameEnglish = dTOProduct.ProductNameEnglish,
                Describtion = dTOProduct.Describtion,
                Content = dTOProduct.Content,
                quantity = dTOProduct.quantity,
                CreatedDate = dTOProduct.CreatedDate,
                Image1 = path1,
                Image2 = path2,
                Image3 = path3,
                price = dTOProduct.price,
            };
            await _db.ProductModel.AddAsync(productModel);
            _db.SaveChanges();


            UserProduct postUser = new UserProduct { ProductId = productModel.Id, UserId = userId };
            _db.UserProduct.Add(postUser);
            await _db.SaveChangesAsync();

            ///// Send Notification for all user

            return Ok(new
            {
                productModel.Id,
                productModel.ProductNameArabic,
                productModel.ProductNameEnglish,
                
                productModel.Describtion,
                productModel.Content,
                productModel.quantity,
                productModel.CreatedDate
            ,
                productModel.price,
                productModel.Image1,
                productModel.Image2,
                productModel.Image3
            });
        }





        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var pack = await _db.ProductModel
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
            return Ok(pack);
        }



        // GET api/<ProductController>/5
        [HttpGet("GetOneProduct")]
        public async Task<IActionResult> GetOneProduct(int id)
        {
            var pack = _db.ProductModel.Where(x => x.Id == id).Select(x => new
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
            });
            return Ok(pack);
        }



        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpatePost([FromRoute] int id, [FromForm] DTOProduct dTOProduct)
        {

            var c = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound(new { Messages = $"Package Id {id} Not Exists" });
            }
            if (dTOProduct.Image1 == null || dTOProduct.Image1.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }

            string path1 = Path.Combine("StaticFile/Images/", dTOProduct.Image1.FileName);
            string fullPath1 = Path.Combine(_host.ContentRootPath.ToString(), path1);

            using (var stream = new FileStream(fullPath1, FileMode.Create))
            {
                await dTOProduct.Image1.CopyToAsync(stream);
            }


            if (dTOProduct.Image2 == null || dTOProduct.Image2.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }


            string path2 = Path.Combine("StaticFile/Images/", dTOProduct.Image2.FileName);
            string fullPath2 = Path.Combine(_host.ContentRootPath.ToString(), path2);

            using (var stream = new FileStream(fullPath2, FileMode.Create))
            {
                await dTOProduct.Image2.CopyToAsync(stream);
            }


            if (dTOProduct.Image3 == null || dTOProduct.Image3.Length == 0)
            {
                return BadRequest(new { Messages = "No file selected." });
            }


            string path3 = Path.Combine("StaticFile/Images/", dTOProduct.Image3.FileName);
            string fullPath3 = Path.Combine(_host.ContentRootPath.ToString(), path3);

            using (var stream = new FileStream(fullPath3, FileMode.Create))
            {
                await dTOProduct.Image3.CopyToAsync(stream);
            }



            if (dTOProduct.ProductNameArabic == null)
                c.ProductNameArabic = c.ProductNameArabic;
            else
                c.ProductNameArabic = dTOProduct.ProductNameArabic;

            if (dTOProduct.ProductNameEnglish == null)
                c.ProductNameEnglish = c.ProductNameEnglish;
            else
                c.ProductNameEnglish = dTOProduct.ProductNameEnglish;

            if (dTOProduct.Content == null)
                c.Content = c.Content;
            else
                c.Content = dTOProduct.Content;


            if (dTOProduct.price.ToString() == null)
                c.price = c.price;
            else
                c.price = dTOProduct.price;


            if (dTOProduct.quantity.ToString() == null)
                c.quantity = c.quantity;
            else
                c.quantity = dTOProduct.quantity;


            if (dTOProduct.Describtion == null)
                c.Describtion = c.Describtion;
            else
                c.Describtion = dTOProduct.Describtion;


            if (dTOProduct.Image1 == null)
                c.Image1 = c.Image1;
            else
                c.Image1 = path1;

            if (dTOProduct.Image2 == null)
                c.Image2 = c.Image2;
            else
                c.Image2 = path2;

            if (dTOProduct.Image3 == null)
                c.Image3 = c.Image3;
            else
                c.Image3 = path3;



            _db.ProductModel.Update(c);
            _db.SaveChanges();


            return Ok(new
            {
                c.Id,
                c.ProductNameArabic,
                c.ProductNameEnglish,
                c.price,
                c.Describtion
            ,
                c.Content,
                c.Image1,
                c.Image2,
                c.Image3,
                c.CreatedDate,
                c.quantity
            });

        }




        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(int id)
        {
            var ads = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id == id);
            if (ads == null)
            {
                return BadRequest(new { Messages ="This Product Is Not Found" });
            }
            _db.ProductModel.Remove(ads);
            _db.SaveChanges();
            return Ok(new { ads.Id,ads.ProductNameEnglish, ads.ProductNameArabic });
        }

    }
}
