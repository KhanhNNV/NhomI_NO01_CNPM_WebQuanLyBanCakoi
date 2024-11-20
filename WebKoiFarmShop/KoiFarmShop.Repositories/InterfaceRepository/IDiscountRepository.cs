using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetAllDiscount();
        Boolean DeleteDiscount(int id);
        Boolean DeleteDiscount(Discount discount);
        Boolean UpdateDiscount(Discount discount);
        Boolean AddDiscount(Discount discount);
        Task<Discount> GetDiscountById(int id);
    }
}
