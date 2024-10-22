using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrder();
        Boolean DeleteOrder(int id);
        Boolean DeleteOrder(Order order);
        Boolean UpdateOrder(Order order);
        Boolean AddOrder(Order order);
        Task<Order> GetAllOrdersById(int id);
    }
}
