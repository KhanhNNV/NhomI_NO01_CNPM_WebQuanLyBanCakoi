using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class CommentBlog
{
    public int CmtBlogId { get; set; }

    public int? BlogId { get; set; }

    public string? Content { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public int? UpdateBy { get; set; }

    public virtual BlogRepository? Blog { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? UpdateByNavigation { get; set; }
}
