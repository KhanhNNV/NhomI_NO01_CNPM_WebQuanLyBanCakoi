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
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public bool AddDiscount(Discount discount)
        {
            return _discountRepository.AddDiscount(discount);
        }

        public bool DeleteDiscount(int id)
        {
           return _discountRepository.DeleteDiscount(id);
        }

        public bool DeleteDiscount(Discount discount)
        {
            return _discountRepository.DeleteDiscount(discount);
        }

        public Task<List<Discount>> GetAllDiscount()
        {
           return _discountRepository.GetAllDiscount();
        }

        public Task<Discount> GetDiscountById(int id)
        {
            return _discountRepository.GetDiscountById(id);
        }

        public bool UpdateDiscount(Discount discount)
        {
            return _discountRepository.UpdateDiscount(discount);
        }
    }
}
