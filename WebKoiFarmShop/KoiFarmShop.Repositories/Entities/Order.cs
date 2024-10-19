using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public double Total { get; set; }

    public int? Status { get; set; }

    public string ShipAddress { get; set; } = null!;

    public int PaymentMethod { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
