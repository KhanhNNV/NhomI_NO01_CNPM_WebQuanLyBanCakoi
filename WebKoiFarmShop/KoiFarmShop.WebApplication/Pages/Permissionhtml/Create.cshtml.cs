using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Permissionhtml
{
    public class CreateModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public CreateModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Permission Permission { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _permissionService.AddPermission(Permission);

            return RedirectToPage("./Index");
        }
    }
}
