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

namespace KoiFarmShop.WebApplication.Pages.Newshtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class EditModel : PageModel
    {
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public EditModel(INewsService newsService, ICategoryService categoryService, IUserService userService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [BindProperty]
        public News News { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news =  await _newsService.GetNewsById((int)id);
            if (news == null)
            {
                return NotFound();
            }
            News = news;
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

            _newsService.UpdateNews(News);

            return RedirectToPage("./Index");
        }

        private bool NewsExists(int id)
        {
            return _newsService.GetNewsById(id)!=null;
        }
    }
}
