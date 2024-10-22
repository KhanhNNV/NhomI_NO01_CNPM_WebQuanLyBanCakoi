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
    public class DetailsModel : PageModel
    {
        private readonly IRoleServices _services;

        public DetailsModel(IRoleServices services)
        {
            _services = services;
        }

        public IRoleServices Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _services.GetRoleById(id.Value);
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
    }
}
