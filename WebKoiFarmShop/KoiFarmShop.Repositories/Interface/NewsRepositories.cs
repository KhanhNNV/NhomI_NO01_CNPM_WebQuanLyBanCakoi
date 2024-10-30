using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace KoiFarmShop.Repositories
{
    public class NewsRepositories : INewsRepositories
    {
        private readonly KoiFarmShopDbContext _context;

        public NewsRepositories(KoiFarmShopDbContext context)
        {
            _context = context;
        }

        public bool AddNews(News news)
        {
            _context.News.Add(news);
            return _context.SaveChanges() > 0;
        }

        public async Task AddNewsAsync(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public bool DelNews(int NewId)
        {
            var news = _context.News.Find(NewId);
            if (news != null)
            {
                _context.News.Remove(news);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DelNews(News news)
        {
            _context.News.Remove(news);
            return _context.SaveChanges() > 0;
        }

        public async Task<News> GetNewsById(int newsId)
        {
            return await _context.News.FindAsync(newsId);
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _context.News.ToListAsync();
        }

        public void Update(News news)
        {
            _context.News.Update(news);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
