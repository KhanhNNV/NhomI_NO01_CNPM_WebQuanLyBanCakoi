using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface ICmtNewsService
    {
        Task<List<CommentNews>> GetAllCmtNews();
        Boolean DelCmtNews(int Id);
        Boolean DelCmtNews(CommentNews cmtNews);
        Boolean AddCmtNews(CommentNews cmtNews);
        Boolean UpCmtNews(CommentNews cmtNews);
        Task<CommentNews> GetCmtNewsById(int Id);
    }
}
