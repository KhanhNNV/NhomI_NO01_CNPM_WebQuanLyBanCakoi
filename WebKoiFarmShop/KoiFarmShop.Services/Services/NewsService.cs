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
    public class NewsService : INewsService
    {
        private readonly INewRepository _newRepository;
        public NewsService(INewRepository newRepository)
        {
            _newRepository = newRepository;
        }

        public bool AddNews(News news)
        {
            return _newRepository.AddNews(news);
        }

        public bool DeleteNews(int id)
        {
            return _newRepository.DeleteNews(id);
        }

        public bool DeleteNews(News news)
        {
            return _newRepository.DeleteNews(news);
        }

        public Task<List<News>> GetAllNews()
        {
            return _newRepository.GetAllNews();
        }

        public Task<News> GetNewsById(int id)
        {
            return _newRepository.GetNewsById(id);
        }

        public bool UpdateNews(News news)
        {
            return _newRepository.UpdateNews(news);
        }
    }
}
