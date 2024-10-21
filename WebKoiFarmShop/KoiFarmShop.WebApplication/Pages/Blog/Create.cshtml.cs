using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages.Account

{
    public class CreateModel : PageModel
    {
        private readonly KoiFarmShopDbContext _service;

        public CreateModel(KoiFarmShopDbContext service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["CateId"] = new SelectList(_service.Categories, "CategoryId", "CategoryName");  
            ViewData["CreatedBy"] = new SelectList(_service.Users, "UserId", "FullName");
            ViewData["UpdateBy"] = new SelectList(_service.Users, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public BlogRepository Blog { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            _service.Blogs.Add(Blog);
            await _service.SaveChangesAsync(); 

            return RedirectToPage("./Index"); 
        }
    }
}
