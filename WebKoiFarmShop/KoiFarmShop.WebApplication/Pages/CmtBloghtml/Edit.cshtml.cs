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
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.CmtBloghtml
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ICmtBlogService _cmtBlogService;
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;

        public EditModel(ICmtBlogService cmtBlogService, IBlogService blogService, IUserService userService)
        {
            _cmtBlogService = cmtBlogService;
            _blogService = blogService;
            _userService = userService;
        }

        [BindProperty]
        public CommentBlog CommentBlog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentblog =  await _cmtBlogService.GetCmtBlogById((int)id);
            if (commentblog == null)
            {
                return NotFound();
            }
            CommentBlog = commentblog;
            var blogs = await _blogService.GetAllBlog();
            var users = await _userService.GetAllUser();
            ViewData["BlogId"] = new SelectList(blogs, "BlogId", "Content");
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
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

            _cmtBlogService.UpCmtBlog(CommentBlog);
           

            return RedirectToPage("./Index");
        }

        private bool CommentBlogExists(int id)
        {
            return _cmtBlogService.GetCmtBlogById(id) != null;  
        }
    }
}
