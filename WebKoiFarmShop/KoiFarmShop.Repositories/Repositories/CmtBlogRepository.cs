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
    public class CmtBlogRepository : ICmtBlogRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public CmtBlogRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCmtBlog(CommentBlog cmtBlog)
        {
            try
            {
                _dbContext.CommentBlogs.Add(cmtBlog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelCmtBlog(int Id)
        {
            try
            {
                var objDel = _dbContext.CommentBlogs.Where(p => p.CmtBlogId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.CommentBlogs.Remove(objDel);
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

        public bool DelCmtBlog(CommentBlog cmtBlog)
        {
            try
            {
                _dbContext.CommentBlogs.Remove(cmtBlog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<CommentBlog>> GetAllCmtBlog()
        {
            return await _dbContext.CommentBlogs
                .Include(c => c.Blog)
                .ToListAsync();
        }

        public async Task<CommentBlog> GetCmtBlogById(int Id)
        {
            return await _dbContext.CommentBlogs
                .Include(c => c.Blog)
                .FirstOrDefaultAsync(o => o.CmtBlogId == Id);
        }

        public bool UpCmtBlog(CommentBlog cmtBlog)
        {
            try
            {
                _dbContext.Attach(cmtBlog).State = EntityState.Modified;
                _dbContext.CommentBlogs.Update(cmtBlog);
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
