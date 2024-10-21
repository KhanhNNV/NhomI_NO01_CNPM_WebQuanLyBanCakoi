using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class KoiCategory
{
    public int KoiCateId { get; set; }

    public int? CateId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();
}
