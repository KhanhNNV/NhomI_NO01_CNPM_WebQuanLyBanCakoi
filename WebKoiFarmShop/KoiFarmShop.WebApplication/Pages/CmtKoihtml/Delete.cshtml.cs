using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtKoihtml
{
    public class DeleteModel : PageModel
    {
        private readonly ICmtKoiService _cmtKoiService;

        public DeleteModel(ICmtKoiService cmtKoiService)
        {
            _cmtKoiService = cmtKoiService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _cmtKoiService.DelCmtKoi((int)id);

            return RedirectToPage("./Index");
        }
    }
}
