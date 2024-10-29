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
    public class CmtKoiService : ICmtKoiService
    {
        private readonly ICmtKoiRepository _repository;
        public CmtKoiService(ICmtKoiRepository repository)
        {
            _repository = repository;
        }

        public bool AddCmtKoi(CommentKoi cmtKoi)
        {
            return _repository.AddCmtKoi(cmtKoi);
        }

        public bool DelCmtKoi(int Id)
        {
           return _repository.DelCmtKoi(Id);
        }

        public bool DelCmtKoi(CommentKoi cmtKoi)
        {
            return _repository.DelCmtKoi(cmtKoi);
        }

        public Task<List<CommentKoi>> GetAllCmtKoi()
        {
            return _repository.GetAllCmtKoi();
        }

        public Task<CommentKoi> GetCmtKoiById(int Id)
        {
            return _repository.GetCmtKoiById(Id);
        }

        public bool UpCmtKoi(CommentKoi cmtKoi)
        {
            return _repository.UpCmtKoi(cmtKoi);
        }
    }
}
