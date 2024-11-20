using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class CommentKoi
{
    public int CmtKoiId { get; set; }

    public int? KoiId { get; set; }

    public string? Content { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public int? UpdateBy { get; set; }

    public virtual Koi? Koi { get; set; }
}
