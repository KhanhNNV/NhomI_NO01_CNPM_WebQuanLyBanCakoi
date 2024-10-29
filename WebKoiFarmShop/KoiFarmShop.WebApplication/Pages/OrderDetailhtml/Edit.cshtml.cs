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

namespace KoiFarmShop.WebApplication.Pages.OrderDetailhtml
{
    public class EditModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IKoiService _koiService;
        private readonly IOrderService _orderService;

        public EditModel(IOrderDetailService orderDetailService, IKoiService koiService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _koiService = koiService;
            _orderService = orderService;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail =  await _orderDetailService.GetOrderDetailById((int)id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            OrderDetail = orderdetail;
            var koi = await _koiService.GetAllKoi();
            var order = await _orderService.GetOrder();
            ViewData["KoiId"] = new SelectList(koi, "KoiId", "KoiId");
            ViewData["OrderId"] = new SelectList(order, "OrderId", "OrderId");
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

           _orderDetailService.UpdateOrderDetail(OrderDetail);

            return RedirectToPage("./Index");
        }

        private bool OrderDetailExists(int id)
        {
            return _orderDetailService.GetOrderDetailById(id) != null;
        }
    }
}
