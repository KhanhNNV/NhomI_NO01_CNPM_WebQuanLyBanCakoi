using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface ICartRepository
    {
        Task AddToCart(int productId, int quantity);
        Task<Order> Checkout();
    }
}
