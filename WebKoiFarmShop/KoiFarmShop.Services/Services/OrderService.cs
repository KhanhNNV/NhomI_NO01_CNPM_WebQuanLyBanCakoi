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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) 
        { 
            _orderRepository = orderRepository;
        }

        public bool AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
        }

        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }

        public bool DeleteOrder(Order order)
        {
            return _orderRepository.DeleteOrder(order) ;
        }

        public Task<Order> GetOrdersById(int id, int userId)
        {
            return _orderRepository.GetOrdersById(id, userId) ;
        }


        public Task<List<Order>> GetAllOrder()
        {
            return _orderRepository.GetAllOrder();
        }

        public bool UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order) ;
        }

        public Task<Order> GetOrdersById(int id)
        {
            return _orderRepository.GetOrdersById(id);
        }
        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _orderRepository.GetOrdersByUserId(userId);
        }

        
    }
}
