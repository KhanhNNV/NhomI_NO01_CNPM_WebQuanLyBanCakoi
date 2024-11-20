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
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;
        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        public bool AddKOi(Koi koi)
        {
            return _koiRepository.AddKOi(koi);
        }

        public bool DelKoi(int Id)
        {
            return _koiRepository.DelKoi(Id);
        }

        public bool DelKoi(Koi koi)
        {
            return _koiRepository.DelKoi(koi);
        }

        public Task<List<Koi>> GetAllKoi()
        {
            return _koiRepository.GetAllKoi();
        }

        public Task<Koi> GetKOiById(int Id)
        {
            return _koiRepository.GetKOiById(Id);
        }

        public Task<List<Koi>> GetKoiByKoiCateId(int KoiCateId)
        {
            return _koiRepository.GetKoiByKoiCateId(KoiCateId);
        }

        public Task<List<Koi>> SearchKois(string search)
        {
            return _koiRepository.SearchKois(search);
        }

        public bool UpKoi(Koi koi)
        {
            return _koiRepository.UpKoi(koi);
        }
    }
}
