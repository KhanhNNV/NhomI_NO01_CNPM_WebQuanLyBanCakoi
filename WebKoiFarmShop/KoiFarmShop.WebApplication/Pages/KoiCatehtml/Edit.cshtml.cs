using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.KoiCatehtml
{
    public class EditModel : PageModel
    {
        private readonly IKoiCateService _koiCateService;
        private readonly ICategoryService _categoryService;

        public EditModel(IKoiCateService koiCateService, ICategoryService categoryService)
        {
            _koiCateService = koiCateService;
            _categoryService = categoryService; 
        }

        [BindProperty]
        public KoiCategory KoiCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koicategory =  await _koiCateService.GetKoiCateById((int)id);
            if (koicategory == null)
            {
                return NotFound();
            }
            KoiCategory = koicategory;
            var cates = await _categoryService.GetAllCategory();
           ViewData["CateId"] = new SelectList(cates, "CategoryId", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _koiCateService.UpdateKoiCate(KoiCategory);

            return RedirectToPage("./Index");
        }

        private bool KoiCategoryExists(int id)
        {
            return _koiCateService.GetKoiCateById(id) != null;
        }
    }
}
