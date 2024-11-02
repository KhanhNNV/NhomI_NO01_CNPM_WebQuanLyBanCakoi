using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Promotionhtml
{
    public class DetailsModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public DetailsModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public Promotion Promotion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _promotionService.GetPromotionById((int)id);
            if (promotion == null)
            {
                return NotFound();
            }
            else
            {
                Promotion = promotion;
            }
            return Page();
        }
    }
}
