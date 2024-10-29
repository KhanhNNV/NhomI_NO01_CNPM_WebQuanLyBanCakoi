using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Newshtml
{
    public class DetailsModel : PageModel
    {
        private readonly INewsService _newsService;

        public DetailsModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public News News { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetNewsById((int)id);
            if (news == null)
            {
                return NotFound();
            }
            else
            {
                News = news;
            }
            return Page();
        }
    }
}
