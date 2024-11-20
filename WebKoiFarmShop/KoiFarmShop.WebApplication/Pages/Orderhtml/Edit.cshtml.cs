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
using KoiFarmShop.Services.Services;
using Microsoft.AspNetCore.Identity;

namespace KoiFarmShop.WebApplication.Pages.Orderhtml
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
        public EditModel(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;

            _userManager = userManager;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrdersById((int)id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;

            var users = _userManager.Users.ToList();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"{error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                //return Page();
            }

            _orderService.UpdateOrder(Order);


            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _orderService.GetOrdersById(id) != null;
        }
    }
}