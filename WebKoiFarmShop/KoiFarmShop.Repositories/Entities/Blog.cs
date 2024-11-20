using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Blog
{
    public int BlogId { get; set; }

    public int? CateId { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public int? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public int? UpdateBy { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual ICollection<CommentBlog> CommentBlogs { get; set; } = new List<CommentBlog>();
}
