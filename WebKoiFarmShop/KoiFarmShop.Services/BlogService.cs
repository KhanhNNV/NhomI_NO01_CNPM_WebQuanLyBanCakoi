using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        
        public Task<List<BlogRepository>> GetAllBlog()
        {
            return _repository.GetAllBlog();
        }

        
        public bool AddBlog(BlogRepository blog)
        {
            return _repository.AddBlog(blog);
        }

        
        public bool DelBlog(int blogId)
        {
            return _repository.DelBlog(blogId);
        }

        
        public bool DelBlog(BlogRepository blog)
        {
            return _repository.DelBlog(blog);
        }

        
        public Task<BlogRepository> GetBlogByID(int blogId)
        {
            return _repository.GetBlogByID(blogId);
        }

        
        public bool UpDBlog(BlogRepository blog)
        {
            return _repository.UpDBlog(blog);
        }

        
        public Task<IList<BlogRepository>> GetBlog(int blogId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogRepository>> GetBlog()
        {
            throw new NotImplementedException();
        }

        public Task<IList<BlogRepository>> Blog()
        {
            throw new NotImplementedException();
        }
    }
}
