using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Boolean DeleteCategory(int id);
        Boolean DeleteCategory(Category category);
        Boolean UpdateCategory(Category category);
        Boolean AddCategory(Category category);
        Task<Category> GetCategoryById(int id);
    }
}
