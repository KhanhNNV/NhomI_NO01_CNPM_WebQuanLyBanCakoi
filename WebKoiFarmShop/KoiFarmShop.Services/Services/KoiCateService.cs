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
    public class KoiCateService : IKoiCateService
    {
        private readonly IKoiCateRepository _koiCateRepository;
        public KoiCateService(IKoiCateRepository koiCateRepository)
        {
            _koiCateRepository = koiCateRepository;
        }

        public bool AddKoiCate(KoiCategory koiCategory)
        {
            return _koiCateRepository.AddKoiCate(koiCategory);
        }

        public bool DeleteKoiCate(int id)
        {
            return _koiCateRepository.DeleteKoiCate(id);
        }

        public bool DeleteKoiCate(KoiCategory koiCategory)
        {
            return _koiCateRepository.DeleteKoiCate(koiCategory);
        }

        public Task<List<KoiCategory>> GetAllKoiCate()
        {
           return _koiCateRepository.GetAllKoiCate();
        }

        public Task<KoiCategory> GetKoiCateById(int id)
        {
            return _koiCateRepository.GetKoiCateById(id);
        }

        public bool UpdateKoiCate(KoiCategory koiCategory)
        {
            return _koiCateRepository.UpdateKoiCate(koiCategory);
        }
    }
}
