using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.InterfaceService;

namespace KoiFarmShop.WebApplication.Pages.CmtBloghtml
{
    public class IndexModel : PageModel
    {
        private readonly ICmtBlogService _cmtBlogService;

        public IndexModel(ICmtBlogService cmtBlogService)
        {
            _cmtBlogService = cmtBlogService;
        }

        public IList<CommentBlog> CommentBlog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CommentBlog = await _cmtBlogService.GetAllCmtBlog();
        }
    }
}
