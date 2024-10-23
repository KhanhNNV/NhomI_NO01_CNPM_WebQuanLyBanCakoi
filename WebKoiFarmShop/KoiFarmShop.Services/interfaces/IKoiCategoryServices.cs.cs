using KoiFarmShop.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Interface
{
    public interface IKoiCategoryServices
    {
        Task<List<KoiCategory>> GetKoiCategories();
        Task<KoiCategory> GetKoiCategoryById(int categoryId);
        bool AddKoiCategory(KoiCategory category);
        bool UpdateKoiCategory(KoiCategory category);
        bool DeleteKoiCategory(int categoryId);
    }
}
