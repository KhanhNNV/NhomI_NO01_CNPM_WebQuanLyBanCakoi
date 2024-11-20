using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Koihtml
{
    [Authorize(Roles = "Manager,Staff")]

    public class CreateModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IKoiCateService _cateService;

        public CreateModel(IKoiService koiService, IKoiCateService cateService)
        {
            _koiService = koiService;
            _cateService = cateService;
        }

        public async Task< IActionResult> OnGetAsync()
        {
            var koicate = await _cateService.GetAllKoiCate();
            ViewData["KoiCateId"] = new SelectList(koicate, "KoiCateId", "Title");
            return Page();
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _koiService.AddKOi(Koi);

            return RedirectToPage("./Index");
        }
    }
}
