using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtBloghtml
{
    public class CreateModel : PageModel
    {
        private readonly ICmtBlogService _cmtBlogService;
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;

        public CreateModel(ICmtBlogService cmtBlogService, IBlogService blogService, IUserService userService)
        {
            _cmtBlogService = cmtBlogService;
            _blogService = blogService;
                _userService = userService;
        }

        public async  Task<IActionResult> OnGetAsync()
        {
            var blogs = await _blogService.GetAllBlog();
            var users = await _userService.GetAllUser();
            ViewData["BlogId"] = new SelectList(blogs, "BlogId", "Content");
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["UpdateBy"] = new SelectList(users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public CommentBlog CommentBlog { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _cmtBlogService.AddCmtBlog(CommentBlog);

            return RedirectToPage("./Index");
        }
    }
}
