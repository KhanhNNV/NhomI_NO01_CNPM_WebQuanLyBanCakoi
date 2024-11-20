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
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Contacthtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class EditModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly UserManager<AppUser> _userManager;

        public EditModel(IContactService contactService, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact =  await _contactService.GetContactById((int)id);
            if (contact == null)
            {
                return NotFound();
            }
            Contact = contact;
            var users = _userManager.Users.ToList();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            _contactService.UpdateContact(Contact);

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return _contactService.GetContactById(id) != null;
        }
    }
}
