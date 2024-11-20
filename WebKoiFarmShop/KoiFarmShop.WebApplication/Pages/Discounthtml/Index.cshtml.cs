using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Discounthtml
{
    public class IndexModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public IndexModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public IList<Discount> Discount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Discount = await _discountService.GetAllDiscount();
        }
    }
}
