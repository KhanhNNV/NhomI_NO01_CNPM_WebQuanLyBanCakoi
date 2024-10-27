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

namespace KoiFarmShop.WebApplication.Pages.Bookinghtml
{
    public class EditModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public EditModel(IBookingService bookingService, ICategoryService categoryService, IUserService userService)
        {
            _bookingService = bookingService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =  await _bookingService.GetBookingById((int)id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
            var cate = await _categoryService.GetAllCategory();
            var user = await _userService.GetAllUser();
            ViewData["CateId"] = new SelectList(cate, "CategoryId", "Title");
            ViewData["CustomerId"] = new SelectList(user, "UserId", "FullName");
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

            _bookingService.UpdateBooking(Booking);

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _bookingService.GetBookingById(id) != null;
        }
    }
}
