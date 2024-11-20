using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;

namespace KoiFarmShop.WebApplication.Pages.Contacthtml
{
    [Authorize(Roles = "Manager,Staff")]
    public class IndexModel : PageModel
    {
        private readonly IContactService _contactService;

        public IndexModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Contact = await _contactService.GetAllContact();
        }
    }
}
