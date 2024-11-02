using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Permissionhtml
{
    public class DetailsModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public DetailsModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public Permission Permission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _permissionService.GetPermissionById((int)id);
            if (permission == null)
            {
                return NotFound();
            }
            else
            {
                Permission = permission;
            }
            return Page();
        }
    }
}
