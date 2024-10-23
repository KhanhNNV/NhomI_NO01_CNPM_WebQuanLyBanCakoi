using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories
{
    internal class KoiCategoryRepositories : IKoiCategoryRepositories
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public KoiCategoryRepositories(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddKoiCategory(KoiCategory category)
        {
            try
            {
                _dbContext.KoiCategories.Add(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DeleteKoiCategory(int categoryId)
        {
            try
            {
                var category = _dbContext.KoiCategories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (category != null)
                {
                    _dbContext.KoiCategories.Remove(category);
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

        public async Task<List<KoiCategory>> GetAllKoiCategories()
        {
            return await _dbContext.KoiCategories.ToListAsync();
        }

        public async Task<KoiCategory> GetKoiCategoryById(int categoryId)
        {
            return await _dbContext.KoiCategories.FindAsync(categoryId);
        }

        public bool UpdateKoiCategory(KoiCategory category)
        {
            try
            {
                _dbContext.KoiCategories.Update(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
