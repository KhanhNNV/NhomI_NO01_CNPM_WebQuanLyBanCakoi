using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? KoiId { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Order? Order { get; set; }
}
