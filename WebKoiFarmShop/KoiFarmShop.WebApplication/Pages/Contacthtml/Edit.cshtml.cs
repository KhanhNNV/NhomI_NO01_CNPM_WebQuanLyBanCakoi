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

namespace KoiFarmShop.WebApplication.Pages.Contacthtml
{
    public class EditModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public EditModel(IContactService contactService, IUserService userService, ICategoryService categoryService)
        {
            _contactService = contactService;
            _userService = userService;
            _categoryService = categoryService;
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
            var cate = await _categoryService.GetAllCategory();
            var user = await _userService.GetAllUser();
            ViewData["CateId"] = new SelectList(cate, "CategoryId", "Title");
            ViewData["UserId"] = new SelectList(user, "UserId", "FullName");
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

            _contactService.UpdateContact(Contact);

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return _contactService.GetContactById(id) != null;
        }
    }
}
