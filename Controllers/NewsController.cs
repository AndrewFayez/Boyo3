using BYO3WebAPI.DTOModels;
using BYO3WebAPI.Models.Data;
using BYO3WebAPI.Models.DataModels.PostModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BYO3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public NewsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST api/<AdsController>
        [HttpPost("AddNews")]
        public async Task<IActionResult> News([FromForm] DTONews dTOAds, string userId)
        {
           
           
            NewsModel Ads = new()
            {
                Title = dTOAds.Title,
            };
            await _db.News.AddAsync(Ads);
            _db.SaveChanges();

            UserNews postUser = new UserNews { UserId = userId, NewsId = Ads.Id };
            _db.UserNews.Add(postUser);
            _db.SaveChanges();


            return Ok(new {Ads.Id,Ads.Title,Ads.CreatedDate});
        }




       

        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            var posts = await _db.News
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.CreatedDate
                }).ToListAsync();
            return Ok(posts);
        }




        // DELETE api/<AdsController>/5
        [HttpDelete("DeleteNews")]
        public async Task<IActionResult> Delete(int id)
        {
            var ads = await _db.News.SingleOrDefaultAsync(x => x.Id == id);
            if (ads == null)
            {
                return BadRequest(new { Messages = "This Is News Not Found"});
            }
            _db.News.Remove(ads);
            _db.SaveChanges();
            return Ok(new {ads.Id, ads.Title , ads.CreatedDate });
        }
    }
}
