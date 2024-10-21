using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public BlogRepository(KoiFarmShopDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool AddBlog(Entities.BlogRepository id)
        {
            try
            {
                _dbContext.Blogs.Add(id);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

            }
            throw new NotFiniteNumberException();
        }

        public bool DelBlog(int blogId)
        {
            try
            {
                var objDel = _dbContext.Blogs.Where(p =>p.BlogID.Equals(blogId)).FirstOrDefault();
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
                return false; 
            }
        }



        public async Task<List<Entities.BlogRepository>> GetAllBlog()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Entities.BlogRepository> GetBlogByID(int Blog)
        {
            return await _dbContext.Blogs.Where(p => p.BlogID.Equals(Blog)).FirstOrDefaultAsync();
        }

        private bool UpDBlog(Entities.BlogRepository id)
        {
            try
            {
                _dbContext.Blogs.Update(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IBlogRepository.AddBlog(Entities.BlogRepository blog)
        {
            throw new NotImplementedException();
        }

        bool IBlogRepository.DelBlog(int id)
        {
            throw new NotImplementedException();
        }

        bool IBlogRepository.DelBlog(Entities.BlogRepository blog)
        {
            throw new NotImplementedException();
        }

        Task<List<Entities.BlogRepository>> IBlogRepository.GetAllBlog()
        {
            throw new NotImplementedException();
        }

        Task<Entities.BlogRepository> IBlogRepository.GetBlogByID(int id)
        {
            throw new NotImplementedException();
        }

        bool IBlogRepository.UpDBlog(Entities.BlogRepository blog)
        {
            throw new NotImplementedException();
        }
    }
}


