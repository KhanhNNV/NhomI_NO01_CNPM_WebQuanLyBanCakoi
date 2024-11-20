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

namespace KoiFarmShop.WebApplication.Pages.Bloghtml
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public EditModel(IBlogService blogService, ICategoryService categoryService, IUserService userService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog =  await _blogService.GetBlogById((int)id);
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
            var cates = await _categoryService.GetAllCategory();
            var users = await _userService.GetAllUser();
            ViewData["CateId"] = new SelectList(cates, "CategoryId", "Title");
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

            _blogService.UpdateBlog(Blog);

            return RedirectToPage("./Index");
        }

        private bool BlogExists(int id)
        {
            return _blogService.GetBlogById(id) != null;
        }
    }
}
