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
    public class IndexModel : PageModel
    {
        private readonly IRoleServices _services;

        public IndexModel(IRoleServices services)
        {
           _services = services;
        }

        public IList<Role> Role_ { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Role_ = await _services.Role();
        }
    }
}
