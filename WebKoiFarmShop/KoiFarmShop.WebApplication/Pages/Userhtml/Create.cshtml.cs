using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Userhtml
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService; 
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var roles = await _roleService.GetAllRole();
            ViewData["RoleId"] = new SelectList(roles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.AddUser(User);

            return RedirectToPage("./Index");
        }
    }
}
