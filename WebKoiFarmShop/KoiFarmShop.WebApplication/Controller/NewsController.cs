using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsServices _newsService;

        public NewsController(INewsServices newsService)
        {
            _newsService = newsService;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetAllNews()
        {
            var news = await _newsService.GetAllNews();
            return Ok(news);
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNewsById(int id)
        {
            var news = await _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // POST: api/News
        [HttpPost]
        public async Task<ActionResult> AddNews([FromBody] News news)
        {
            await _newsService.AddNewsAsync(news);
            return CreatedAtAction(nameof(GetNewsById), new { id = news.NewId }, news);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNews(int id, [FromBody] News updatedNews)
        {
            var existingNews = await _newsService.GetNewsById(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            existingNews.Title = updatedNews.Title;
            existingNews.Content = updatedNews.Content;
            existingNews.Image = updatedNews.Image;

            await _newsService.UpdateNews(existingNews);
            return NoContent();
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNews(int id)
        {
            var news = await _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }

             _newsService.DelNews(id);
            return NoContent();
        }
    }
}
