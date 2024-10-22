using KoiFarmShop.Repositories.Entities;
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
        public async Task<List<Order>> GetAllOrder()
        {
            return await _dbContext.Orders.ToListAsync();
        }
    }
}
