using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages
{
    public class EditModel : PageModel
    {
        private readonly KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext _context;

        public EditModel(KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CommentBlog CommentBlog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentblog = await _context.CommentBlogs.FirstOrDefaultAsync(m => m.CmtBlogId == id);
            if (commentblog == null)
            {
                return NotFound();
            }
            CommentBlog = commentblog;
            ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["UpdateBy"] = new SelectList(_context.Users, "UserId", "FullName");
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

            _context.Attach(CommentBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentBlogExists(CommentBlog.CmtBlogId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CommentBlogExists(int id)
        {
            return _context.CommentBlogs.Any(e => e.CmtBlogId == id);
        }
    }
}
