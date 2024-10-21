using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Koi
{
    public int KoiId { get; set; }

    public int? KoiCateId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public int? Age { get; set; }

    public double? Size { get; set; }

    public string? Breed { get; set; }

    public int? Gender { get; set; }

    public string? Origin { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<CommentKoi> CommentKois { get; set; } = new List<CommentKoi>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual KoiCategory? KoiCate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
