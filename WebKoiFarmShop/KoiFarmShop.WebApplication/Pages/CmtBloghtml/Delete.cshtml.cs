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

namespace KoiFarmShop.WebApplication.Pages.CmtBloghtml
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ICmtBlogService _cmtBlogService;

        public DeleteModel(ICmtBlogService cmtBlogService)
        {
            _cmtBlogService = cmtBlogService;
        }

        [BindProperty]
        public CommentBlog CommentBlog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentblog = await _cmtBlogService.GetCmtBlogById((int)id);

            if (commentblog == null)
            {
                return NotFound();
            }
            else
            {
                CommentBlog = commentblog;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           _cmtBlogService.DelCmtBlog((int)id);

            return RedirectToPage("./Index");
        }
    }
}
