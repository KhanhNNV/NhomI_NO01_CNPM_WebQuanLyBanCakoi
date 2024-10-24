using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface ICmtBlogRepository
    {
        Task<List<CommentBlog>> GetAllCmtBlog();
        Boolean DelCmtBlog(int Id);
        Boolean DelCmtBlog(CommentBlog cmtBlog);
        Boolean AddCmtBlog(CommentBlog cmtBlog);
        Boolean UpCmtBlog(CommentBlog cmtBlog);
        Task<CommentBlog> GetCmtBlogById(int Id);
    }
}
