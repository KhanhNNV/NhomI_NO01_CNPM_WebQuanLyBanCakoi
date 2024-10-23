using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interface;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages.Category
{
    public class CategoryPageModel : PageModel
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryPageModel(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public Category Category { get; set; } = new Category();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _categoryServices.GetCategoryById(id.Value);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Category.CateId > 0)
            {
                _categoryServices.UpdateCategory(Category);
            }
            else
            {
                _categoryServices.AddCategory(Category);
            }

            return RedirectToPage("./Index");
        }
    }
}
