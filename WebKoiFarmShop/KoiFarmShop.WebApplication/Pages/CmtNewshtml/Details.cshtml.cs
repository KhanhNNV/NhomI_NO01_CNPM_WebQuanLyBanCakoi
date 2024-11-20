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

namespace KoiFarmShop.WebApplication.Pages.CmtNewshtml
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ICmtNewsService _newsService;

        public DetailsModel(ICmtNewsService newsService)
        {
            _newsService = newsService; ;
        }

        public CommentNews CommentNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentnews = await _newsService.GetCmtNewsById((int)id);
            if (commentnews == null)
            {
                return NotFound();
            }
            else
            {
                CommentNews = commentnews;
            }
            return Page();
        }
    }
}
