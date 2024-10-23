using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.KoiCatehtml
{
    public class IndexModel : PageModel
    {
        private readonly IKoiCateService _koiCateService;

        public IndexModel(IKoiCateService koiCateService)
        {
            _koiCateService = koiCateService;
        }

        public IList<KoiCategory> KoiCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiCategory = await _koiCateService.GetAllKoiCate();
        }
    }
}
