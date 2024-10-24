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
    public class IndexModel : PageModel
    {
        private readonly ICmtNewsService _newsService;

        public IndexModel(ICmtNewsService newsService)
        {
            _newsService=newsService; ;
        }

        public IList<CommentNews> CommentNews { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CommentNews = await _newsService.GetAllCmtNews();
        }
    }
}
