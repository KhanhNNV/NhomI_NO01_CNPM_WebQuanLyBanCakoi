using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interface
{
    public interface INewsServices
    {
        bool AddNews(News news);
        Task AddNewsAsync(News news);
        bool DelNews(int NewId);
        bool DelNews(News news);
        Task<News> GetNewsById(int newsId);
        Task<List<News>> GetAllNews();
        Task UpdateNews(News news);
        Task SaveChangesAsync();
    }
}
