using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class CmtNewsRepository : ICmtNewsRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public CmtNewsRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddCmtNews(CommentNews cmtNews)
        {
            try
            {
                _dbContext.CommentNews.Add(cmtNews);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCmtNews(int Id)
        {
            try
            {
                var objDel = _dbContext.CommentNews.Where(p => p.CmtNewsId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.CommentNews.Remove(objDel);
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

        public bool DelCmtNews(CommentNews cmtNews)
        {
            try
            {
                _dbContext.CommentNews.Remove(cmtNews);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<CommentNews>> GetAllCmtNews()
        {
           return await _dbContext.CommentNews
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.News)
                .Include(c => c.UpdateByNavigation).ToListAsync();
        }

        public async Task<CommentNews> GetCmtNewsById(int Id)
        {
            return await _dbContext.CommentNews
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.News)
                .Include(c => c.UpdateByNavigation).FirstOrDefaultAsync(o => o.CmtNewsId == Id);
        }

        public bool UpCmtNews(CommentNews cmtNews)
        {
            try
            {
                _dbContext.Attach(cmtNews).State = EntityState.Modified;
                _dbContext.CommentNews.Update(cmtNews);
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
