using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using KoiFarmShop.Services.Services;

namespace KoiFarmShop.WebApplication.Pages.Newshtml
{
    public class CreateModel : PageModel
    {
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public CreateModel(INewsService newsService, ICategoryService categoryService, IUserService userService)
        {
            _newsService = newsService;
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
        public News News { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _newsService.AddNews(News);

            return RedirectToPage("./Index");
        }
    }
}
