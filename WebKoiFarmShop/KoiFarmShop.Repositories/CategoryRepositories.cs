using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories
{
    internal class CategoryRepositories : ICategoryRepositories
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public CategoryRepositories(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int cateId)
        {
            return await _dbContext.Categories.FindAsync(cateId);
        }

        public bool AddCategory(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int cateId)
        {
            try
            {
                var category = _dbContext.Categories.Find(cateId);
                if (category != null)
                {
                    _dbContext.Categories.Remove(category);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
