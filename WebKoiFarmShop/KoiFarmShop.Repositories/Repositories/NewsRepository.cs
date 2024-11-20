using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class NewsRepository : INewRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public NewsRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddNews(News news)
        {
            try
            {
                _dbContext.News.Add(news);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteNews(int id)
        {
            try
            {
                var objDel = _dbContext.News.Where(p => p.NewId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.News.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteNews(News news)
        {
            try
            {
                _dbContext.News.Remove(news);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _dbContext.News
                .Include(n => n.Cate)
                .ToListAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _dbContext.News
                .Include(n => n.Cate)
               .FirstOrDefaultAsync(o => o.NewId == id);
        }

        public bool UpdateNews(News news)
        {
            try
            {
                _dbContext.Attach(news).State = EntityState.Modified;
                _dbContext.News.Update(news);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
