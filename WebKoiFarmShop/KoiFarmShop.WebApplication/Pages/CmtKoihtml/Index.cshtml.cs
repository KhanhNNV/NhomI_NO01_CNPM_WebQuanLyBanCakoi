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

namespace KoiFarmShop.WebApplication.Pages.CmtKoihtml
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICmtKoiService _cmtKoiService;

        public IndexModel(ICmtKoiService cmtKoiService)
        {
            _cmtKoiService = cmtKoiService;
        }

        public IList<CommentKoi> CommentKoi { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CommentKoi = await _cmtKoiService.GetAllCmtKoi();
        }
    }
}
