using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtKoihtml
{
    public class CreateModel : PageModel
    {
        private readonly ICmtKoiService _cmtKoiService;
        private readonly IUserService _userService;
        private readonly IKoiService _koiService;

        public CreateModel(ICmtKoiService cmtKoi, IUserService userService, IKoiService koiService)
        {
            _cmtKoiService = cmtKoi;
            _userService = userService;
            _koiService = koiService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var users = await _userService.GetAllUser();
            var kois= await _koiService.GetAllKoi();
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["KoiId"] = new SelectList(kois, "KoiId", "Title");
            ViewData["UpdateBy"] = new SelectList(users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public CommentKoi CommentKoi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _cmtKoiService.AddCmtKoi(CommentKoi);

            return RedirectToPage("./Index");
        }
    }
}
