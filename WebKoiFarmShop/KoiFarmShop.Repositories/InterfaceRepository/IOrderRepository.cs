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
        Boolean DeleteOrder(int id);
        Boolean DeleteOrder(Order order);
        Boolean UpdateOrder(Order order);
        Boolean UpdateOrder(int id);
        Boolean AddOrder(Order order);
        Task<Order> GetAllOrdersById(int id);


    }
}
