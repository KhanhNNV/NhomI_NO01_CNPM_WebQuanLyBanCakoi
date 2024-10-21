using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext _context;

        public DetailsModel(KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext context)
        {
            _context = context;
        }

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
            else
            {
                CommentBlog = commentblog;
            }
            return Page();
        }
    }
}
