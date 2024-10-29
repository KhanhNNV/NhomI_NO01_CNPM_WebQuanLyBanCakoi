using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.OrderDetailhtml
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;

        public IndexModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _orderDetailService.GetAllOrderDetail();
        }
    }
}
