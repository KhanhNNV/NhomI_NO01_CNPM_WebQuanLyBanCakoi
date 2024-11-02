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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public bool DeleteOrderDetail(int id)
        {
            return _orderDetailRepository.DeleteOrderDetail(id);
        }

        public bool DeleteOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailRepository.DeleteOrderDetail(orderDetail);
        }

        public Task<List<OrderDetail>> GetAllOrderDetail()
        {
            return _orderDetailRepository.GetAllOrderDetail();
        }

        public Task<OrderDetail> GetOrderDetailById(int id)
        {
            return _orderDetailRepository.GetOrderDetailById(id);
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            return _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
