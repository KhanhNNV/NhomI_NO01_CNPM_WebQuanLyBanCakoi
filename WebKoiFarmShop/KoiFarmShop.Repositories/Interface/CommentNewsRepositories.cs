using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class CommentNewsRepositories : ICommentNewsRepositories
    {
        private readonly KoiFarmShopDbContext _context;

        public CommentNewsRepositories(KoiFarmShopDbContext context)
        {
            _context = context;
        }

        public bool AddComment(CommentNews comment)
        {
            _context.CommentNews.Add(comment);
            return _context.SaveChanges() > 0;
        }

        public async Task AddCommentAsync(CommentNews comment)
        {
            _context.CommentNews.Add(comment);
            await _context.SaveChangesAsync();
        }

        public bool DelComment(int CommentId)
        {
            var comment = _context.CommentNews.Find(CommentId);
            if (comment != null)
            {
                _context.CommentNews.Remove(comment);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<CommentNews> GetCommentById(int commentId)
        {
            return await _context.CommentNews.FindAsync(commentId);
        }

        public async Task<List<CommentNews>> GetCommentsForNews(int newsId)
        {
            return await _context.CommentNews.Where(c => c.NewsId == newsId).ToListAsync();
        }

        public void Update(CommentNews comment)
        {
            _context.CommentNews.Update(comment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
