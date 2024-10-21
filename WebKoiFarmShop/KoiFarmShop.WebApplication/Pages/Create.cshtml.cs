using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages
{
    public class CreateModel : PageModel
    {
        private readonly KoiFarmShopDbContext _context;

        public CreateModel(KoiFarmShopDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["UpdateBy"] = new SelectList(_context.Users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public CommentBlog CommentBlog { get; set; } = new CommentBlog();
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CommentBlogs.Add(CommentBlog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

