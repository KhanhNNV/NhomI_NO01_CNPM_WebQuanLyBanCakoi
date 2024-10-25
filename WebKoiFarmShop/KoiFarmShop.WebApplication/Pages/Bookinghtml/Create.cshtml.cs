using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Bookinghtml
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public CreateModel(IBookingService bookingService, ICategoryService categoryService, IUserService userService)
        {
            _bookingService = bookingService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public async Task <IActionResult> OnGetAsync()
        {
            var cate= await _categoryService.GetAllCategory();
            var user= await _userService.GetAllUser();
            ViewData["CateId"] = new SelectList(cate, "CategoryId", "Title");
            ViewData["CustomerId"] = new SelectList(user, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           _bookingService.AddBooking(Booking);

            return RedirectToPage("./Index");
        }
    }
}
