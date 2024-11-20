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

namespace KoiFarmShop.WebApplication.Pages.Promotionhtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class CreateModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public CreateModel(IPromotionService promotionService)
        {
           _promotionService = promotionService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _promotionService.AddPromotion(Promotion);

            return RedirectToPage("./Index");
        }
    }
}
