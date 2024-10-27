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

namespace KoiFarmShop.WebApplication.Pages.CmtNewshtml
{
    public class EditModel : PageModel
    {
        private readonly ICmtNewsService _cmtnewsService;
        private readonly INewsService _newsService;
        private readonly IUserService _userService;

        public EditModel(ICmtNewsService cmtnewsService, INewsService newsService, IUserService userService)
        {
            _cmtnewsService = cmtnewsService;
            _newsService = newsService;
            _userService = userService;
        }

        [BindProperty]
        public CommentNews CommentNews { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentnews =  await _cmtnewsService.GetCmtNewsById((int)id);
            if (commentnews == null)
            {
                return NotFound();
            }
            CommentNews = commentnews;
            var users = await _userService.GetAllUser();
            var news = await _newsService.GetAllNews();
            ViewData["CreatedBy"] = new SelectList(users, "UserId", "FullName");
            ViewData["NewsId"] = new SelectList(news, "NewId", "Content");
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

            _cmtnewsService.UpCmtNews(CommentNews);

            return RedirectToPage("./Index");
        }

        private bool CommentNewsExists(int id)
        {
            return _cmtnewsService.GetCmtNewsById(id) != null;
        }
    }
}
