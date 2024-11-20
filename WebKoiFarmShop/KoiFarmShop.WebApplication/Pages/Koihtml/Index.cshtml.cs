using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Koihtml
{
    public class IndexModel : PageModel
    {
        private readonly IKoiService _koiService;

        public IndexModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public IList<Koi> Koi { get;set; } = default!;
        public async Task OnGetAsync()
        {
            Koi = await _koiService.GetAllKoi();
           
        }
        
    }
}
