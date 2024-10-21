using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.Account
{
    public class IndexModel : PageModel
    {

        private readonly IBlogService _service;

        public IndexModel(IBlogService service)
        {
            _service = service;
        }

        public IList<BlogRepository> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blog = await _service.Blog();   
        }
    }
}
