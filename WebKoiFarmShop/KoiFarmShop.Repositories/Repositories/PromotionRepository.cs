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
    public class PromotionRepository : IPromotionRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public PromotionRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddPromotion(Promotion promotion)
        {
            try
            {
                _dbContext.Promotions.Add(promotion);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeletePromotion(int id)
        {
            try
            {
                var objDel = _dbContext.Promotions.Where(p => p.ProId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Promotions.Remove(objDel);
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

        public bool DeletePromotion(Promotion promotion)
        {
            try
            {
                _dbContext.Promotions.Remove(promotion);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Promotion>> GetAllPromotion()
        {
            return await _dbContext.Promotions.ToListAsync();
        }

        public async Task<Promotion> GetPromotionById(int id)
        {
            return await _dbContext.Promotions.Where(o => o.ProId.Equals(id)).FirstOrDefaultAsync();
        }

        public bool UpdatePromotion(Promotion promotion)
        {
            try
            {
                _dbContext.Attach(promotion).State = EntityState.Modified;
                _dbContext.Promotions.Update(promotion);
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
