﻿using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public OrderRepository(KoiFarmShopDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public bool AddOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Database update error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var objDel = _dbContext.Orders.Where(p
                    => p.OrderId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Orders.Remove(objDel);
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

        public bool DeleteOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                   
            }
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _dbContext.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetAllOrdersById(int id)
        {
            return await _dbContext.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
        }


        public bool UpdateOrder(Order order)
        {
            try
            {
                _dbContext.Attach(order).State = EntityState.Modified;
                _dbContext.Orders.Update(order);
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
