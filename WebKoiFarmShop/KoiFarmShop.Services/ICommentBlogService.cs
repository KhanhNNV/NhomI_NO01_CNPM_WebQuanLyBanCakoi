using System;
using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services
{
	public interface ICommentBlogService
	{
		Task<List<CommentBlog>> CommentBlog();
        Task<IList<CommentBlogRepository>> CommentBlogs();
        Task<List<CommentBlogRepository>> GetAllBlogComment();
        Boolean DelBlog(int ID);
        Boolean DelBlog(CommentBlogRepository commentBlog);
        Boolean AddBlog(CommentBlogRepository commentBlog);
        Boolean UpDBlog(CommentBlogRepository commentBlog);
        Task<CommentBlogRepository> GetCommentBlogByID(int ID);
    }
}

