using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.lienHe
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(IContactService contactService, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Contact.CateId = 5;
            Contact.UserId = currentUser.Id;

            _contactService.AddContact(Contact);

            return Page();
        }
    }
}
