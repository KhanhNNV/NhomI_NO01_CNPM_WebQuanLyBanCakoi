using System;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services.InterfaceService
{
    public interface IBlogService
    {
        Task<List<BlogRepository>> GetBlog();
        Task<IList<BlogRepository>> Blog();
        Task<List<BlogRepository>> GetAllBlog();
        Boolean DelBlog(int blog);
        Boolean DelBlog(BlogRepository b);
        Boolean AddBlog(BlogRepository b);
        Boolean UpDBlog(BlogRepository bl);
        Task<BlogRepository> GetBlogByID(int b);
    }
}

