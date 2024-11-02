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

namespace KoiFarmShop.WebApplication.Pages.Permissionhtml
{
    public class EditModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public EditModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Permission Permission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission =  await _permissionService.GetPermissionById((int)id);
            if (permission == null)
            {
                return NotFound();
            }
            Permission = permission;
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

            _permissionService.UpdatePermission(Permission);

            return RedirectToPage("./Index");
        }

        private bool PermissionExists(int id)
        {
            return _permissionService.GetPermissionById(id) != null;
        }
    }
}
