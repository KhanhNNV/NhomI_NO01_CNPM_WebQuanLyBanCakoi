using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface INewRepository
    {
        Task<List<News>> GetAllNews();
        Boolean DeleteNews(int id);
        Boolean DeleteNews(News news);
        Boolean UpdateNews(News news);
        Boolean AddNews(News news);
        Task<News> GetNewsById(int id);
    }
}
