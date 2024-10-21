using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class CommentBlogRepository : ICommentBlogRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public CommentBlogRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public bool AddCommentBlog(CommentBlog commentBlog)
        {
            try
            {
                _dbContext.CommentBlogs.Add(commentBlog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        public async Task<CommentBlog> CommentBlogByID(int ID)
        {
            return await _dbContext.CommentBlogs.FindAsync(ID);
        }

        
        public bool DelCommentBlog(int ID)
        {
            try
            {
                var objDel = _dbContext.CommentBlogs.Where(p => p.CmtBlogId == ID).FirstOrDefault();
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        public bool DelCommentBlog(CommentBlog commentBlog)
        {
            try
            {
                _dbContext.CommentBlogs.Remove(commentBlog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

       
        public async Task<List<CommentBlog>> GetCommentBlog()
        {
            return await _dbContext.CommentBlogs.ToListAsync();
        }

        
        public bool UpdCommentBlog(CommentBlog commentBlog)
        {
            try
            {
                _dbContext.CommentBlogs.Update(commentBlog);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
