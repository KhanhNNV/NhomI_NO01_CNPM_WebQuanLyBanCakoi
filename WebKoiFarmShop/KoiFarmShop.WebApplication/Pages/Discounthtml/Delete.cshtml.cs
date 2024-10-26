﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;

namespace KoiFarmShop.WebApplication.Pages.Discounthtml
{
    public class DeleteModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public DeleteModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _discountService.GetDiscountById((int)id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _discountService.DeleteDiscount((int) id);

            return RedirectToPage("./Index");
        }
    }
}