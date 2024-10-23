using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.KoiCatehtml
{
    public class CreateModel : PageModel
    {
        private readonly IKoiCateService _koiCateService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IKoiCateService koiCateService, ICategoryService categoryService)
        {
            _koiCateService = koiCateService;
            _categoryService = categoryService;
        }

        public async Task< IActionResult> OnGetAsync()
        {
            var cates = await _categoryService.GetAllCategory();
            ViewData["CateId"] = new SelectList(cates, "CategoryId", "Title");
            return Page();
        }

        [BindProperty]
        public KoiCategory KoiCategory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _koiCateService.AddKoiCate(KoiCategory);

            return RedirectToPage("./Index");
        }
    }
}
