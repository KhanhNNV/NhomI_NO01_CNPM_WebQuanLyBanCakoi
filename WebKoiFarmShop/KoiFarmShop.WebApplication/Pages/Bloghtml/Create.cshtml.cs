using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using System.Configuration;

namespace KoiFarmShop.WebApplication.Pages.Bloghtml
{
    public class CreateModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public CreateModel(IBlogService blogService,ICategoryService categoryService,IUserService userService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cates = await _categoryService.GetAllCategory();
            var users = await _userService.GetAllUser();
            ViewData["CateId"] = new SelectList(cates, "CategoryId", "Title"); 
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["UpdateBy"] = new SelectList(users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           _blogService.AddBlog(Blog);

            return RedirectToPage("./Index");
        }
    }
}
