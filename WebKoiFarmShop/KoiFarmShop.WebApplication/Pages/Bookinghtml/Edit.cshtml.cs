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
using Microsoft.AspNetCore.Identity;
using KoiFarmShop.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Bookinghtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class EditModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<AppUser> _userManager;

        public EditModel(IBookingService bookingService, UserManager<AppUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
            
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
            var users = _userManager.Users.ToList();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

            _bookingService.UpdateBooking(Booking);

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _bookingService.GetBookingById(id) != null;
        }
    }
}
