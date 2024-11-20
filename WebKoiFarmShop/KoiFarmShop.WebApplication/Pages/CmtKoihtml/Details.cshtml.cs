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
    public class DetailsModel : PageModel
    {
        private readonly ICmtKoiService _cmtKoiService;

        public DetailsModel(ICmtKoiService cmtKoiService)
        {
            _cmtKoiService = cmtKoiService;
        }

        public CommentKoi CommentKoi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentkoi = await _cmtKoiService.GetCmtKoiById((int)id);
            if (commentkoi == null)
            {
                return NotFound();
            }
            else
            {
                CommentKoi = commentkoi;
            }
            return Page();
        }
    }
}
