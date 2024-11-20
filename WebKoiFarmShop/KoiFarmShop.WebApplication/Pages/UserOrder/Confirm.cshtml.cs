using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace KoiFarmShop.WebApplication.Pages.UserOrder
{
    [Authorize]
    public class ConfirmModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public ConfirmModel(IOrderService orderService, UserManager<AppUser> userManager, IKoiService koiService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _koiService = koiService;
        }

        public Order Order { get; set; }
        public Koi Koi { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string userName { get; set; }
        public AppUser users { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login"); 
            }
            userName = currentUser.UserName;

            
            
            Order = await _orderService.GetOrdersById(orderId,currentUser.Id);

            if (Order == null)
            {
                return NotFound(); 
            }

           
            Koi =await _koiService.GetKOiById((int)Order.KoiId);
            users = currentUser; 

            if (Koi == null)
            {
                return NotFound(); 
            }

            TotalAmount = Order.Total;
            Quantity = Order.Quantity;

            return Page();
        }
    }
}
