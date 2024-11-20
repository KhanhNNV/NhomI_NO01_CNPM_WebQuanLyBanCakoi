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

namespace KoiFarmShop.WebApplication.Pages.Discounthtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class EditModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IDiscountService _discountService;

        public EditModel(IKoiService koiService, IDiscountService discountService)
        {
            _discountService = discountService;
            _koiService = koiService;
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _discountService.GetDiscountById((int) id);
            if (discount == null)
            {
                return NotFound();
            }
            Discount = discount;
            var kois = await _koiService.GetAllKoi();
            var promotions = await _discountService.GetAllDiscount();
            ViewData["KoiId"] = new SelectList(kois, "KoiId", "KoiId");
           ViewData["ProId"] = new SelectList(promotions, "ProId", "ProId");
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

            _discountService.UpdateDiscount(Discount);

            return RedirectToPage("./Index");
        }

        private bool DiscountExists(int id)
        {
            return _discountService.GetDiscountById(id) != null; 
        }
    }
}
