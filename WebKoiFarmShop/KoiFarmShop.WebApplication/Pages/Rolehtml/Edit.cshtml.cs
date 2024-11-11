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
using Microsoft.AspNetCore.Identity;

namespace KoiFarmShop.WebApplication.Pages.Rolehtml
{
    public class EditModel : PageModel
    {
        private readonly IRoleService _roleService;

        public EditModel(IRoleService roleService)
        {
            _roleService= roleService;
        }

        [BindProperty]
        public IdentityRole<int> Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role =  await _roleService.GetRoleById((int)id);
            if (role == null)
            {
                return NotFound();
            }
            Role = role;
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

            await _roleService.UpRole(Role);

            
            return RedirectToPage("./Index");
        }

        private bool RoleExists(int id)
        {
            return _roleService.GetRoleById(id) != null;
        }
    }
}
