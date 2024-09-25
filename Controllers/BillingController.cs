using BYO3WebAPI.DTOModels.BillProduct;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.DillsModel;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using BYO3WebAPI.Services.Email;
using BYO3WebAPI.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {

    
        private readonly ApplicationDbContext _db;


        public BillingController( ApplicationDbContext db)
        {
            _db = db;
        }



        [HttpPost("CreateBill")]
        public async Task<ActionResult<BillModel>> CreateBillProductAsync(string userId  )
        {

            var bill = new BillModel
            {
                DateTime = DateTime.Now,
                TotalAmount = 0
                };

                _db.Bill.Add(bill);
                 _db.SaveChanges();

            UserBills billProducts = new UserBills { UserId = userId, BillId = bill.Id };

            await _db.UserBills.AddAsync(billProducts);
            _db.SaveChanges();

            return Ok(new { bill.Id , bill.DateTime , bill.TotalAmount});
  
        }


        [HttpGet("GetBillsForUser")]
        public async Task<IActionResult> GetBillsForUser(string userId)
        {
                var bill = await _db.UserBills.Where(x => x.UserId == userId)
                    .SelectMany(P => P.Bill.UserBills.Select(x => new
                    {
                        x.BillId, 
                        x.UserId,
                        x.Bill.DateTime,
                        x.Bill.TotalAmount,
                        x.User.FullName,
                        x.User.PhoneNumber,
                        x.User.Email,
                       products = x.Bill.BillProducts.Select(x=>new { x.Product.ProductNameArabic, x.Product.Describtion ,x.Quentity, x.Product.price})
                    })).ToListAsync();
             
            return Ok(bill);
        }
      
        


        
        [HttpGet("GetAllBillsAdmin")]
        public async Task<IActionResult> GetAllBills()
        { 
            var bill = await _db.UserBills
                .SelectMany(P => P.Bill.UserBills.Select(x => new
                {
                    x.BillId,
                    x.UserId,
                    x.Bill.DateTime,
                    x.Bill.TotalAmount,
                    x.User.FullName,
                    x.User.PhoneNumber,
                    x.User.Email,
                    products = x.Bill.BillProducts.Select(x => new { x.Product.ProductNameArabic, x.Product.Describtion, x.Quentity, x.Product.price })
                })).ToListAsync();

            return Ok(bill);
        }





        [HttpPost("AddProductInBill")]

        public async Task<IActionResult> AddProductInBill([FromForm]DTOProductBill dTOProductBill)
        {
            var product = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id == dTOProductBill.productId);
            if (product == null)
            {
                return NotFound(new { Messages = $"Product with ID {dTOProductBill.productId} not found" });
            }
            var billing = await _db.Bill.SingleOrDefaultAsync(x => x.Id == dTOProductBill.BillId );
            if (billing == null)
            {
                return NotFound(new { Messages = $"Product with ID {dTOProductBill.productId} not found" });
            }

            var addProduct = new BillProducts
            {
                BillId = dTOProductBill.BillId,
                ProductId = dTOProductBill.productId,
                Quentity = dTOProductBill.Quentity
            };

            if (product.quantity < addProduct.Quentity) {
                return NotFound(new { Messages = $"You Should lettel Amount" });

            }

            await _db.BillProducts.AddAsync(addProduct);
            _db.SaveChanges();

            var count = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id == product.Id);
              count.quantity = product.quantity - addProduct.Quentity;
            _db.ProductModel.Update(count);
            _db.SaveChanges();


            var totalAmount = await _db.Bill.SingleOrDefaultAsync(x => x.Id == dTOProductBill.BillId && product.Id== dTOProductBill.productId);

            totalAmount.TotalAmount += (int)(addProduct.Quentity * product.price);
            _db.Bill.Update(totalAmount);
            _db.SaveChanges();


            return Ok(new { addProduct.ProductId , addProduct.BillId , addProduct.Quentity});
        }




        [HttpDelete("DeleteProductFromBill")]
        public async Task<IActionResult> DeleteProduct(int billId , int productId)
        {
            var product = await _db.BillProducts.SingleOrDefaultAsync(x => x.ProductId == productId && x.BillId == billId);
            if(product == null)
            {
                return BadRequest(new { Messages = "Product Is Not Found"});
            }
            var productAmount = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id ==productId && x.quantity > 0);
            if (product == null)
            {
                return NotFound(new { Messages = $"Product With ID {productId} Not Found" });
            }
            var totalAmount = await _db.Bill.SingleOrDefaultAsync(x => x.Id == billId);

            totalAmount.TotalAmount -= (int)(product.Quentity * productAmount.price);
            _db.Bill.Update(totalAmount);
            _db.SaveChanges();


            var count = await _db.ProductModel.SingleOrDefaultAsync(x => x.Id == productAmount.Id);
            count.quantity += product.Quentity ;
            _db.ProductModel.Update(count);
            _db.SaveChanges();

            _db.BillProducts.Remove(product);
            _db.SaveChanges();
            return Ok(new { product.ProductId , productAmount.ProductNameArabic, product.Quentity ,totalAmount.TotalAmount});
        }





        [HttpDelete("DeleteBill")]
        public async Task<IActionResult> DeleteBill(int billId , string userId)
        {
            var bill = await _db.Bill.SingleOrDefaultAsync(x => x.Id == billId);
            var userBill = await _db.UserBills.SingleOrDefaultAsync(x => x.BillId == billId && x.UserId == userId);
            var billproduct = await _db.BillProducts.SingleOrDefaultAsync(x=>x.BillId==billId && x.ProductId==x.ProductId);
            if (bill == null)
            {
                return BadRequest(new { Messages = "Bill Is Not Found"});
            }
            if (userBill == null)
            {
                return BadRequest(new { Messages = "User Bill Is Not Found"});
            }
            _db.UserBills.Remove(userBill);
            _db.SaveChanges();

            _db.BillProducts.Remove(billproduct);
            _db.SaveChanges();

            _db.Bill.Remove(bill);
            _db.SaveChanges();
            return Ok(new { bill.Id,bill.DateTime,bill.TotalAmount });
        }



    }
}
