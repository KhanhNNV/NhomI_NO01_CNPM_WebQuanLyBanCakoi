using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public bool AddBlog(Blog blog)
        {
            return _blogRepository.AddBlog(blog);
        }

        public bool DeleteBlog(int id)
        {
            return _blogRepository.DeleteBlog(id);
        }

        public bool DeleteBlog(Blog blog)
        {
            return _blogRepository.DeleteBlog(blog);
        }

        public Task<List<Blog>> GetAllBlog()
        {
            return _blogRepository.GetAllBlog();
        }

        public Task<Blog> GetBlogById(int id)
        {
            return _blogRepository.GetBlogById(id);
        }

        public bool UpdateBlog(Blog blog)
        {
            return _blogRepository.UpdateBlog(blog);
        }
    }
}
