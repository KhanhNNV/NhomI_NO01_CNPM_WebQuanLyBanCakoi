using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtNewshtml
{
    public class CreateModel : PageModel
    {
        private readonly ICmtNewsService _cmtnewsService;
        private readonly INewsService _newsService;
        private readonly IUserService _userService;

        public CreateModel(ICmtNewsService cmtnewsService, INewsService newsService, IUserService userService)
        {
           _cmtnewsService = cmtnewsService;
            _newsService = newsService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var users= await _userService.GetAllUser();
            var news= await _newsService.GetAllNews();
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["NewsId"] = new SelectList(news, "NewId", "Content");
            ViewData["UpdateBy"] = new SelectList(users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public CommentNews CommentNews { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _cmtnewsService.AddCmtNews(CommentNews);

            return RedirectToPage("./Index");
        }
    }
}
