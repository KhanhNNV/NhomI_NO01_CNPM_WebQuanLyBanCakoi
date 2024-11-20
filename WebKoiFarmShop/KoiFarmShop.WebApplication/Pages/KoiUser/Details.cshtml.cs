using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.KoiUser
{
    
    public class DetailsModel : PageModel
    {
        private readonly IKoiService _koiService;

        public DetailsModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koi = await _koiService.GetKOiById((int)id);
            if (koi == null)
            {
                return NotFound();
            }
            else
            {
                Koi = koi;
            }
            return Page();
        }
    }
}
