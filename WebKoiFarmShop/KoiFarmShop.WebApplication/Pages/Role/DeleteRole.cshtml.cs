using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interface;

namespace KoiFarmShop.WebApplication.Pages.Role
{
    public class DeleteModel : PageModel
    {
        private readonly IRoleServices _services;

        public DeleteModel(IRoleServices services)
        {
            _services = services;
        }

        [BindProperty]
        public KoiFarmShop.Services.RoleServices Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            var role = await _services.GetRoleById(Id);

            if (role == null)
            {
                return NotFound();
            }
            else
            {
                Role = Role;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _services.DelRole((int)id);
            return RedirectToPage("./Index");
        }
    }
}
