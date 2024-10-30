using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.KoiCatehtml
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiCateService _koiCateService;

        public DetailsModel(IKoiCateService koiCateService)
        {
            _koiCateService = koiCateService;
        }

        public KoiCategory KoiCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koicategory = await _koiCateService.GetKoiCateById((int)id);
            if (koicategory == null)
            {
                return NotFound();
            }
            else
            {
                KoiCategory = koicategory;
            }
            return Page();
        }
    }
}
