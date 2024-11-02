using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetail();
        Boolean DeleteOrderDetail(int id);
        Boolean DeleteOrderDetail(OrderDetail orderDetail);
        Boolean UpdateOrderDetail(OrderDetail orderDetail);
        Boolean AddOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailById(int id);
    }
}
