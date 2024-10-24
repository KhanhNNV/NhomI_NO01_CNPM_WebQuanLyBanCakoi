using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentNewsController : ControllerBase
    {
        private readonly ICommentNewsServices _commentService;

        public CommentNewsController(ICommentNewsServices commentService)
        {
            _commentService = commentService;
        }

        // GET: api/CommentNews/news/5
        [HttpGet("news/{newsId}")]
        public async Task<ActionResult<IEnumerable<CommentNews>>> GetCommentsForNews(int newsId)
        {
            var comments = await _commentService.GetCommentsForNews(newsId);
            return Ok(comments);
        }

        // GET: api/CommentNews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentNews>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST: api/CommentNews
        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody] CommentNews comment)
        {
            await _commentService.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.CmtNewsId }, comment);
        }

        // PUT: api/CommentNews/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, [FromBody] CommentNews updatedComment)
        {
            var existingComment = await _commentService.GetCommentById(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            existingComment.Content = updatedComment.Content;

            await _commentService.UpdateComment(existingComment);
            return NoContent();
        }

        // DELETE: api/CommentNews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.DelComment(id);
            return NoContent();
        }
    }
}
