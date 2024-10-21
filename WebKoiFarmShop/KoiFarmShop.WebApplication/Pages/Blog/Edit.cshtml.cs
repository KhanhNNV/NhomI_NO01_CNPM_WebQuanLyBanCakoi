using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext _context;

        public EditModel(KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogRepository Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog =  await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
           ViewData["CateId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
           ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "FullName");
           ViewData["UpdateBy"] = new SelectList(_context.Users, "UserId", "FullName");
            return Page();
        }

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(Blog.BlogId))
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

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
