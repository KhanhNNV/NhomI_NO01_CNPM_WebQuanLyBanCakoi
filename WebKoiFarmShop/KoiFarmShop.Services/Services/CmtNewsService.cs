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
    public class CmtNewsService : ICmtNewsService
    {
        private readonly ICmtNewsRepository _cmtnewsRepository;
        public CmtNewsService(ICmtNewsRepository cmtnewsRepository)
        {
            _cmtnewsRepository = cmtnewsRepository;
        }

        public bool AddCmtNews(CommentNews cmtNews)
        {
            return _cmtnewsRepository.AddCmtNews(cmtNews);
        }

        public bool DelCmtNews(int Id)
        {
            return _cmtnewsRepository.DelCmtNews(Id);
        }

        public bool DelCmtNews(CommentNews cmtNews)
        {
            return _cmtnewsRepository.DelCmtNews(cmtNews);
        }

        public Task<List<CommentNews>> GetAllCmtNews()
        {
            return _cmtnewsRepository.GetAllCmtNews();
        }

        public Task<CommentNews> GetCmtNewsById(int Id)
        {
            return _cmtnewsRepository.GetCmtNewsById(Id);
        }

        public bool UpCmtNews(CommentNews cmtNews)
        {
            return _cmtnewsRepository.UpCmtNews(cmtNews);
        }
    }
}
