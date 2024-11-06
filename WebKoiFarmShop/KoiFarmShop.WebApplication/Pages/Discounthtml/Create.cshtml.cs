using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Discounthtml
{
    public class CreateModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IPromotionService _promotionService;
        private readonly IDiscountService _discountService;

        public CreateModel(IKoiService koiService, IPromotionService promotionService, IDiscountService discountService)
        {
            _promotionService = promotionService;
            _koiService = koiService;
            _discountService = discountService;
        }

        public async Task<IActionResult> OnGetAsync() 
        {
            var kois = await _koiService.GetAllKoi();
            var promotions = await _promotionService.GetAllPromotion();
        ViewData["KoiId"] = new SelectList(kois, "KoiId", "Title");
        ViewData["ProId"] = new SelectList(promotions, "ProId", "ProId");
            return Page();
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _discountService.AddDiscount(Discount);

            return RedirectToPage("./Index");
        }
    }
}
