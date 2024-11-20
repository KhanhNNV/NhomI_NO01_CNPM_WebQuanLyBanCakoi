using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Identity;
using KoiFarmShop.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.KyguiCa
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(IBookingService bookingService, UserManager<AppUser> userManager)
        {
            _bookingService = bookingService;
           
            _userManager = userManager;
        }


       

        public async Task <IActionResult> OnGetAsync(int BookingId)
        {
            
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Booking.CateId = 2;
            Booking.UserId = currentUser.Id;


            _bookingService.AddBooking(Booking);


            return RedirectToPage("/KyguiCa/Confirm", new { bookingId = Booking.BookingId });
           
        }
    }
}
