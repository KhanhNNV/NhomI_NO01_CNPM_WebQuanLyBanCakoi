using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Discount
{
    public int DiscountId { get; set; }

    public int? ProId { get; set; }

    public int? KoiId { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Promotion? Pro { get; set; }
}
