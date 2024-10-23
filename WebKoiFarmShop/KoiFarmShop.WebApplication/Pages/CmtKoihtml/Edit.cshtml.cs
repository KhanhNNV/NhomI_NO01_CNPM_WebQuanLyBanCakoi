using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtKoihtml
{
    public class EditModel : PageModel
    {
        private readonly ICmtKoiService _cmtKoiService;
        private readonly IUserService _userService;
        private readonly IKoiService _koiService;

        public EditModel(ICmtKoiService cmtKoi, IUserService userService, IKoiService koiService)
        {
            _cmtKoiService = cmtKoi;
            _userService = userService;
            _koiService = koiService;
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
            CommentKoi = commentkoi;
            var users = await _userService.GetAllUser();
            var kois = await _koiService.GetAllKoi();
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["KoiId"] = new SelectList(kois, "KoiId", "Title");
            ViewData["UpdateBy"] = new SelectList(users, "UserId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _cmtKoiService.UpCmtKoi(CommentKoi);

            return RedirectToPage("./Index");
        }

        private bool CommentKoiExists(int id)
        {
            return _cmtKoiService.GetCmtKoiById(id) != null;
        }
    }
}
