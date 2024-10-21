using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Promotion
{
    public int ProId { get; set; }

    public DateOnly? DayStart { get; set; }

    public DateOnly? DayEnd { get; set; }

    public double? Percent { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
