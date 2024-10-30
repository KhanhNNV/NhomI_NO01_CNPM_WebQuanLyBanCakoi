using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtNewshtml
{
    public class DeleteModel : PageModel
    {
        private readonly ICmtNewsService _newsService;

        public DeleteModel(ICmtNewsService newsService)
        {
            _newsService = newsService; ;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _newsService.DelCmtNews((int)id);

            return RedirectToPage("./Index");
        }
    }
}
