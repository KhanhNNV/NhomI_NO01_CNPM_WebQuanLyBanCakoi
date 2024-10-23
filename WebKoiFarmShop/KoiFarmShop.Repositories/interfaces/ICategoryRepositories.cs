using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interface
{
    public interface ICategoryRepositories
    {
        Task<List<Category>> GetAllCategories(); // Lấy tất cả danh mục
        Task<Category> GetCategoryById(int cateId); // Lấy danh mục theo ID
        bool AddCategory(Category category); // Thêm danh mục
        bool UpdateCategory(Category category); // Cập nhật danh mục
        bool DeleteCategory(int cateId); // Xóa danh mục
    }
}
