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

namespace KoiFarmShop.WebApplication.Pages.Orderhtml
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public EditModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order =  await _orderService.GetAllOrdersById((int)id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;

            var users = await _userService.GetAllUser();
            ViewData["CustomerId"] = new SelectList(users, "UserId", "FullName");
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

            _orderService.UpdateOrder(Order);


            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _orderService.GetAllOrdersById(id) != null;
        }
    }
}
