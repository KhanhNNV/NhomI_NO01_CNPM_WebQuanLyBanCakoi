using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();

    }
}
