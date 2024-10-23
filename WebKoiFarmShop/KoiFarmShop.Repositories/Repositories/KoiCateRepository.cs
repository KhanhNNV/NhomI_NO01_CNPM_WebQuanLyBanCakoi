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
    public class KoiCateRepository : IKoiCateRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public KoiCateRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddKoiCate(KoiCategory koiCategory)
        {
            try
            {
                _dbContext.KoiCategories.Add(koiCategory);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteKoiCate(int id)
        {
            try
            {
                var objDel = _dbContext.KoiCategories.Where(p => p.KoiCateId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.KoiCategories.Remove(objDel);
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

        public bool DeleteKoiCate(KoiCategory koiCategory)
        {
            try
            {
                _dbContext.KoiCategories.Remove(koiCategory);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<KoiCategory>> GetAllKoiCate()
        {
            return await _dbContext.KoiCategories.Include(u => u.Cate).ToListAsync();
        }

        public async Task<KoiCategory> GetKoiCateById(int id)
        {
            return await _dbContext.KoiCategories.Include(o => o.Cate).FirstOrDefaultAsync(o => o.KoiCateId == id);
        }

        public bool UpdateKoiCate(KoiCategory koiCategory)
        {
            try
            {
                _dbContext.Attach(koiCategory).State = EntityState.Modified;
                _dbContext.KoiCategories.Update(koiCategory);
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
