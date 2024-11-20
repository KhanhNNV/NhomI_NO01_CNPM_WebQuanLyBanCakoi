// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KoiFarmShop.WebApplication.Pages.Userhtml
{
    [Authorize(Roles = "Manager")]
    public class AddRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public AddRoleModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
       

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        
        public AppUser user { get; set; }
        [BindProperty]
        [DisplayName("Role")]
        public string RoleName { get; set; } 
        public SelectList allRole { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return NotFound($"Không thấy user, id={id}.");

            var userRoles = await _userManager.GetRolesAsync(user);
            RoleName = userRoles.FirstOrDefault(); // Lấy vai trò đầu tiên nếu có
            allRole = new SelectList(await _roleManager.Roles.Select(x => x.Name).ToListAsync());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return NotFound($"Không thấy user, id={id}.");

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Any())
            {
                var resultRemove = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!resultRemove.Succeeded)
                {
                    resultRemove.Errors.ToList().ForEach(error => ModelState.AddModelError(string.Empty, error.Description));
                    return Page();
                }
            }

            if (!string.IsNullOrEmpty(RoleName))
            {
                var resultAdd = await _userManager.AddToRoleAsync(user, RoleName);
                if (!resultAdd.Succeeded)
                {
                    resultAdd.Errors.ToList().ForEach(error => ModelState.AddModelError(string.Empty, error.Description));
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}


