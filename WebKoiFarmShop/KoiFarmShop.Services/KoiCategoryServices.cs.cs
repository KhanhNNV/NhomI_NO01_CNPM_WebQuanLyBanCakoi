using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interface;
using KoiFarmShop.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFarmShop.Services
{
    public class KoiCategoryServices : IKoiCategoryServices
    {
        private readonly IKoiCategoryRepositories _koiCategoryRepositories;

        public KoiCategoryServices(IKoiCategoryRepositories koiCategoryRepositories)
        {
            _koiCategoryRepositories = koiCategoryRepositories;
        }

        public bool AddKoiCategory(KoiCategory category)
        {
            return _koiCategoryRepositories.AddKoiCategory(category);
        }

        public bool DeleteKoiCategory(int categoryId)
        {
            return _koiCategoryRepositories.DeleteKoiCategory(categoryId);
        }

        public async Task<List<KoiCategory>> GetKoiCategories()
        {
            return await _koiCategoryRepositories.GetAllKoiCategories();
        }

        public async Task<KoiCategory> GetKoiCategoryById(int categoryId)
        {
            return await _koiCategoryRepositories.GetKoiCategoryById(categoryId);
        }

        public bool UpdateKoiCategory(KoiCategory category)
        {
            return _koiCategoryRepositories.UpdateKoiCategory(category);
        }
    }
}
