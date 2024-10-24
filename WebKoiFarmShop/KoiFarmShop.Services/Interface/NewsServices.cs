using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class NewsServices : INewsServices
    {
        private readonly INewsRepositories _repositories;

        public NewsServices(INewsRepositories repositories)
        {
            _repositories = repositories;
        }

        public bool AddNews(News news)
        {
            return _repositories.AddNews(news);
        }

        public async Task AddNewsAsync(News news)
        {
            await _repositories.AddNewsAsync(news);
        }

        public bool DelNews(int NewId)
        {
            return _repositories.DelNews(NewId);
        }

        public bool DelNews(News news)
        {
            return _repositories.DelNews(news);
        }

        public async Task<News> GetNewsById(int newsId)
        {
            return await _repositories.GetNewsById(newsId);
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _repositories.GetAllNews();
        }

        public async Task UpdateNews(News news)
        {
            _repositories.Update(news);
            await _repositories.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repositories.SaveChangesAsync();
        }
    }
}
