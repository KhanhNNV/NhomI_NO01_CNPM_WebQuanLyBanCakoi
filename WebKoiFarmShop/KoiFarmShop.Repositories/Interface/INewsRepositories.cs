using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interface
{
    public interface INewsRepositories
    {
        bool AddNews(News news);
        Task AddNewsAsync(News news);
        bool DelNews(int NewId);
        bool DelNews(News news);
        Task<News> GetNewsById(int newsId);
        Task<List<News>> GetAllNews();
        void Update(News news);
        Task SaveChangesAsync();
    }
}
