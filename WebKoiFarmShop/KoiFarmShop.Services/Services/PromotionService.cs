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
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }
        public bool AddPromotion(Promotion promotion)
        {
            return _promotionRepository.AddPromotion(promotion);
        }

        public bool DeletePromotion(int id)
        {
            return _promotionRepository.DeletePromotion(id);
        }

        public bool DeletePromotion(Promotion promotion)
        {
            return _promotionRepository.DeletePromotion(promotion);
        }

        public Task<List<Promotion>> GetAllPromotion()
        {
            return _promotionRepository.GetAllPromotion();
        }

        public Task<Promotion> GetPromotionById(int id)
        {
            return _promotionRepository.GetPromotionById(id);
        }

        public bool UpdatePromotion(Promotion promotion)
        {
            return _promotionRepository.UpdatePromotion(promotion);
        }
    }
}
