using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.KoiUser
{
    public class IndexModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IKoiCateService _koiCateService;

        public IndexModel(IKoiService koiService, IKoiCateService koiCateService)
        {
            _koiService = koiService;
            _koiCateService = koiCateService;
        }

        public IList<Koi> Kois { get;set; } = default!;
        public async Task OnGetAsync(int koicateId)
        {
            Kois = await _koiService.GetKoiByKoiCateId(koicateId);
           
        }
        
    }
}
