using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services;

namespace KoiFarmShop.WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICommentBlogService _service;

        public IndexModel(ICommentBlogService service)
        {
            _service = service;
        }

        public IList<CommentBlog> CommentBlog { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CommentBlog = (IList<CommentBlog>)await _service.CommentBlog();
        }
    }
}

