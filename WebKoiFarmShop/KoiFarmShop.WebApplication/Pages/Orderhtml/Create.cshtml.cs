using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Orderhtml
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        public CreateModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //public IActionResult OnGet()
        //{
           
        //    ViewData["CustomerId"] = new SelectList(_context.Users, "UserId", "FullName");
        //    return Page();
        //}

        [BindProperty]
        public Order Order_ { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             _orderService.AddOrder(Order_);

            return RedirectToPage("./Index");
        }
    }
}
