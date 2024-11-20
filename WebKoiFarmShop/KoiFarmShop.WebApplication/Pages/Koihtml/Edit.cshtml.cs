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
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Koihtml
{
    [Authorize(Roles = "Manager,Staff")]

    public class EditModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IKoiCateService _koiCateService;

        public EditModel(IKoiService koiService, IKoiCateService koiCateService)
        {
            _koiService = koiService;
            _koiCateService = koiCateService;
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi =  await _koiService.GetKOiById((int)id);
            if (koi == null)
            {
                return NotFound();
            }
            Koi = koi;
            var koicate = await _koiCateService.GetAllKoiCate();
           ViewData["KoiCateId"] = new SelectList(koicate, "KoiCateId", "Title");
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

            _koiService.UpKoi(Koi);

            return RedirectToPage("./Index");
        }

        private bool KoiExists(int id)
        {
            return _koiService.GetKOiById(id) != null;
        }
    }
}
