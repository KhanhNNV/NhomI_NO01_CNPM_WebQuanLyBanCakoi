using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Discounthtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class DetailsModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public DetailsModel(DiscountService discountService)
        {
            _discountService = discountService;   
        }

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
            else
            {
                Discount = discount;
            }
            return Page();
        }
    }
}
