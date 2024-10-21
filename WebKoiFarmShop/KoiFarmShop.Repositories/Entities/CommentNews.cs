using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class CommentNews
{
    public int CmtNewsId { get; set; }

    public int? NewsId { get; set; }

    public string? Content { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public int? UpdateBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual News? News { get; set; }

    public virtual User? UpdateByNavigation { get; set; }
}
