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

namespace KoiFarmShop.WebApplication.Pages.Promotionhtml
{
    public class EditModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public EditModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion =  await _promotionService.GetPromotionById((int)id);
            if (promotion == null)
            {
                return NotFound();
            }
            Promotion = promotion;
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

            _promotionService.UpdatePromotion(Promotion);

            return RedirectToPage("./Index");
        }

        private bool PromotionExists(int id)
        {
            return _promotionService.GetPromotionById(id) != null;
        }
    }
}
