﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interface;

namespace KoiFarmShop.WebApplication.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly IRoleServices _services;
        public CreateModel(IRoleServices services)
        {
            _services = services;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiFarmShop.Services.RoleServices Role { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _services.AddRoleAsync(Role);
            return RedirectToPage("./Index");
        }
    }
}
