using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Interface
{
    public interface IKoiCategoryRepositories
    {
        Task<List<KoiCategory>> GetAllKoiCategories();
        Task<KoiCategory> GetKoiCategoryById(int categoryId);
        bool AddKoiCategory(KoiCategory category);
        bool UpdateKoiCategory(KoiCategory category);
        bool DeleteKoiCategory(int categoryId);
    }
}
