using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogService _service;
        private BlogRepository blog1;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DeleteModel(IBlogService service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _service = service;
        }

        [BindProperty]
        public IBlogService blog { get; set; } = default!;
        public Repositories.Entities.BlogRepository Blog { get => blog1; private set => blog1 = value; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int ID = (int)id;
            var blog = await _service.GetBlogByID(ID);
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelBlog((int)id);
            return RedirectToPage("./Index");
        }
    }
}
