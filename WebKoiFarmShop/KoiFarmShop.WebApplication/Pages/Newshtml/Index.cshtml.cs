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

namespace KoiFarmShop.WebApplication.Pages.Newshtml
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public IndexModel(INewsService newsService)
        {
            _newsService    = newsService;
        }

        public IList<News> News { get;set; } = default!;

        public async Task OnGetAsync()
        {
            News = await _newsService.GetAllNews();
        }
    }
}
