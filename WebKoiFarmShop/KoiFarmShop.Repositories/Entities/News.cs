using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class News
{
    public int NewId { get; set; }

    public int? CateId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public int? UpdateBy { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual ICollection<CommentNews> CommentNews { get; set; } = new List<CommentNews>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? UpdateByNavigation { get; set; }
}
