using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarmShop.WebApplication.Pages.UserOrder
{
    [Authorize]
    public class CreateModel : PageModel
    {
        
        private readonly IKoiService _koiService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(IKoiService koiService, UserManager<AppUser> userManager, IOrderService orderService)
        {
            _koiService = koiService;
            _userManager = userManager;
            _orderService = orderService;
        }

        [BindProperty]
        public Koi Koi { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public string ShipAddress { get; set; }
        
        [BindProperty]
        public string PaymentMethod { get; set; }

        public async Task<IActionResult> OnGetAsync(int koiID)
        {
            
            Koi = await _koiService.GetKOiById((int)koiID);

            if (Koi == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, int quantity)
        {
            
            Koi = await _koiService.GetKOiById((int)id);

            if (Koi == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            
            var totalAmount = Koi.Price * quantity;


            var order = new Order
            {
                KoiId = id,
                Quantity = quantity,
                Total = totalAmount,
                CreatedDay = DateOnly.FromDateTime(DateTime.Now),
                Status = 0,
                ShipAddress = ShipAddress,
                UserId = currentUser.Id,
                PaymentMethod = int.Parse(PaymentMethod)
            };

            
            _orderService.AddOrder(order);

            return RedirectToPage("/UserOrder/Confirm", new { orderId = order.OrderId });
        }
    }
}
