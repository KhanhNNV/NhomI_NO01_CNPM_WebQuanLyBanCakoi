using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext _context;

        public DetailsModel(KoiFarmShop.Repositories.Entities.KoiFarmShopDbContext context)
        {
            _context = context;
        }

        public BlogRepository Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
