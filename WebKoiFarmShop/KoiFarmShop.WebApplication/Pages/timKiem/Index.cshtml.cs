using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.timKiem
{
    
    public class IndexModel : PageModel
    {
        private readonly IKoiService _koiService;

        public IndexModel(IKoiService koiService)
        {
            _koiService = koiService;
        }
        public string? Search { get; set; }
        public IList<Koi> Koi { get;set; } = default!;
        public async Task OnGetAsync(string? Search)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                Koi = await _koiService.SearchKois(Search); 
            }
            else
            {
                Koi = await _koiService.GetAllKoi(); 
            }

        }
        
    }
}
