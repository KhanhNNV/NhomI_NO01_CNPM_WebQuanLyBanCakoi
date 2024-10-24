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
    public class CmtBlogService : ICmtBlogService
    {
        private readonly ICmtBlogRepository _blogRepository;
        public CmtBlogService(ICmtBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public bool AddCmtBlog(CommentBlog cmtBlog)
        {
            return _blogRepository.AddCmtBlog(cmtBlog);
        }

        public bool DelCmtBlog(int Id)
        {
            return _blogRepository.DelCmtBlog(Id);
        }

        public bool DelCmtBlog(CommentBlog cmtBlog)
        {
            return _blogRepository.DelCmtBlog(cmtBlog);
        }

        public Task<List<CommentBlog>> GetAllCmtBlog()
        {
            return _blogRepository.GetAllCmtBlog();
        }

        public Task<CommentBlog> GetCmtBlogById(int Id)
        {
            return _blogRepository.GetCmtBlogById(Id);
        }

        public bool UpCmtBlog(CommentBlog cmtBlog)
        {
            return _blogRepository.UpCmtBlog(cmtBlog);
        }
    }
}
