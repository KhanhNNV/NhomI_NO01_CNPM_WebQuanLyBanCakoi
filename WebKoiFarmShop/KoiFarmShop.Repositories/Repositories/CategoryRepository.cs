using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Repositories
{
    public class CategoryRepository : ICaragoryRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;
        public CategoryRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddCategory(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var objDel = _dbContext.Categories.Where(p
                    => p.CategoryId.Equals(id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Categories.Remove(objDel);
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

        public bool DeleteCategory(Category category)
        {
            try
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());

            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _dbContext.Categories.Where(p => p.CategoryId.Equals(id)).FirstOrDefaultAsync();
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _dbContext.Attach(category).State = EntityState.Modified;
                _dbContext.Categories.Update(category);
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
