using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace KoiFarmShop.WebApplication.Pages.KyguiCa
{
    public class ConfirmModel : PageModel
    {
        private readonly IBookingService _bookingService;
        
        private readonly UserManager<AppUser> _userManager;

        public ConfirmModel(IBookingService bookingService, UserManager<AppUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
            
        }

        public Booking Booking { get; set; }
        public string koiName   { get; set; }
        public DateOnly DateSent { get; set; }
        public DateOnly DateReceived { get; set; }
        public int Status { get; set; }
        public string userName { get; set; }
        public AppUser users { get; set; }

        public async Task<IActionResult> OnGetAsync(int bookingId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login"); 
            }
            userName = currentUser.UserName;



            Booking = await _bookingService.GetBookingById(bookingId, currentUser.Id);

            if (Booking == null)
            {
                return NotFound(); 
            }

           
            users = currentUser; 

           

            return Page();
        }
    }
}
