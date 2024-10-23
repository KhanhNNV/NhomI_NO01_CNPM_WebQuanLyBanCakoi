using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interface
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int cateId);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int cateId);
    }
}
