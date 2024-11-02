using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public OrderDetailRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.OrderDetails.Add(orderDetail);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteOrderDetail(int id)
        {
            try
            {
                var objDel = _dbContext.OrderDetails.Where(p => p.OrderDetailId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.OrderDetails.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<OrderDetail>> GetAllOrderDetail()
        {
           return await _dbContext.OrderDetails
                .Include(o => o.Koi)
                .Include(o => o.Order).ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _dbContext.OrderDetails
                .Include(o => o.Koi)
                .Include(o => o.Order).FirstOrDefaultAsync(o => o.OrderDetailId == id);
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _dbContext.Attach(orderDetail).State = EntityState.Modified;
                _dbContext.OrderDetails.Update(orderDetail);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
