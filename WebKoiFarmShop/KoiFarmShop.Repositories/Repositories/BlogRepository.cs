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
    public class BlogRepository : IBlogRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public BlogRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddBlog(Blog blog)
        {
            try
            {
                _dbContext.Blogs.Add(blog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteBlog(int id)
        {
            try
            {
                var objDel = _dbContext.Blogs.Where(p => p.BlogId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Blogs.Remove(objDel);
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

        public bool DeleteBlog(Blog blog)
        {
            try
            {
                _dbContext.Blogs.Remove(blog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Blog>> GetAllBlog()
        {
            return await _dbContext.Blogs
                .Include(b => b.Cate)
                .ToListAsync();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _dbContext.Blogs
                .Include(b => b.Cate)
                .FirstOrDefaultAsync(o => o.BlogId == id);
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                _dbContext.Attach(blog).State = EntityState.Modified;
                _dbContext.Blogs.Update(blog);
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
