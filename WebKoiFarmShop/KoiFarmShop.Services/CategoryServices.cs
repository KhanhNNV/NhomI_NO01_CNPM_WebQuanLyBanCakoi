using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepositories _categoryRepositories;

        public CategoryServices(ICategoryRepositories categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepositories.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int cateId)
        {
            return await _categoryRepositories.GetCategoryById(cateId);
        }

        public bool AddCategory(Category category)
        {
            return _categoryRepositories.AddCategory(category);
        }

        public bool UpdateCategory(Category category)
        {
            return _categoryRepositories.UpdateCategory(category);
        }

        public bool DeleteCategory(int cateId)
        {
            return _categoryRepositories.DeleteCategory(cateId);
        }
    }
}
