using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using System.Transactions;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Promotionhtml
{
    public class IndexModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public IndexModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public IList<Promotion> Promotion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Promotion = await _promotionService.GetAllPromotion();
        }
    }
}
