using System;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Repositories.InterfaceRepository
{
	public interface IBlogRepository
	{
		Task<List<Entities.BlogRepository>> GetAllBlog();
		Boolean DelBlog(int blog);
		Boolean DelBlog(Entities.BlogRepository blog);
        Boolean AddBlog(Entities.BlogRepository blog);
        Boolean UpDBlog(Entities.BlogRepository blog);
		Task<Entities.BlogRepository> GetBlogByID(int blog);
    }
}

