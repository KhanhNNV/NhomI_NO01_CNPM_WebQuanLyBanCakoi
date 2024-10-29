using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.OrderDetailhtml
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IKoiService _koiService;
        private readonly IOrderService _orderService;

        public CreateModel(IOrderDetailService orderDetailService, IKoiService koiService,IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _koiService = koiService;
            _orderService = orderService;   
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var koi = await _koiService.GetAllKoi();
            var order = await _orderService.GetOrder();
            ViewData["KoiId"] = new SelectList(koi, "KoiId", "KoiId");
            ViewData["OrderId"] = new SelectList(order, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderDetailService.AddOrderDetail(OrderDetail);

            return RedirectToPage("./Index");
        }
    }
}
