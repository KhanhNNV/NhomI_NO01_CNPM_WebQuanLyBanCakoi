using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Contacthtml
{
    public class CreateModel : PageModel
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IContactService contactService, IUserService userService, ICategoryService categoryService)
        {
            _contactService = contactService;
            _userService = userService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cate = await _categoryService.GetAllCategory();
            var user = await _userService.GetAllUser(); 
            ViewData["CateId"] = new SelectList(cate, "CategoryId", "Title");
            ViewData["UserId"] = new SelectList(user, "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactService.AddContact(Contact);

            return RedirectToPage("./Index");
        }
    }
}
