using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Userhtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        

        public class UserRole : AppUser
        {
            public string RoleNames { get; set; }
        }
        public List<UserRole> users { get; set; }
        public async Task OnGetAsync()
        {
            var qr = _userManager.Users.OrderBy(u => u.UserName)
                       .Select(u => new UserRole
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                       });

            users = await qr.ToListAsync();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.RoleNames = string.Join(",", roles);
            }
        }

        public void OnPost() => RedirectToPage();
    }
}
