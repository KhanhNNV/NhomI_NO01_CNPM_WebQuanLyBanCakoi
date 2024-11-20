using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Boolean DeleteOrder(int id);
        Boolean DeleteOrder(Order order);
        Boolean UpdateOrder(Order order);
        Boolean AddOrder(Order order);
        Task<Order> GetOrdersById(int id);
        Task<Order> GetOrdersById(int id,int userId);
        Task<List<Order>> GetOrdersByUserId(int userId);


    }
}
