using System;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Repositories.InterfaceRepository
{
	public interface ICommentBlogRepository
	{ 
		Task<List<CommentBlog>> GetCommentBlog();
		Boolean DelCommentBlog(int ID);
		Boolean DelCommentBlog(CommentBlog commentBlog);
		Boolean AddCommentBlog(CommentBlog commentBlog);
		Boolean UpdCommentBlog(CommentBlog commentBlog);
		Task<CommentBlog> CommentBlogByID(int ID);
	}
}

