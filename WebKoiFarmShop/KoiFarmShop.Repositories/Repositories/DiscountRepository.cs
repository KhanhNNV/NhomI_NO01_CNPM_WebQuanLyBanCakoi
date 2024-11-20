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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public DiscountRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddDiscount(Discount discount)
        {
            try
            {
                _dbContext.Discounts.Add(discount);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteDiscount(int id)
        {
            try
            {
                var objDel = _dbContext.Discounts.Where(p => p.DiscountId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Discounts.Remove(objDel);
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

        public bool DeleteDiscount(Discount discount)
        {
            try
            {
                _dbContext.Discounts.Remove(discount);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Discount>> GetAllDiscount()
        {
            return await _dbContext.Discounts
                .Include(d => d.Koi)
                .Include(d => d.Pro).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            return await _dbContext.Discounts
                .Include(d => d.Koi)
                .Include(d => d.Pro).FirstOrDefaultAsync(o => o.DiscountId == id);
        }

        public bool UpdateDiscount(Discount discount)
        {
            try
            {
                _dbContext.Attach(discount).State = EntityState.Modified;
                _dbContext.Discounts.Update(discount);
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
