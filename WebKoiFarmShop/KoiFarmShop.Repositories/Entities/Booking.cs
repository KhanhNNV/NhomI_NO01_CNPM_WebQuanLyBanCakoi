using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? CateId { get; set; }

    public int? CustomerId { get; set; }

    public string? Koiname { get; set; }

    public string? Description { get; set; }

    public int? Age { get; set; }

    public double? Size { get; set; }

    public string? Breed { get; set; }

    public int? Gender { get; set; }

    public string? Origin { get; set; }

    public string? Image { get; set; }

    public int? Quantity { get; set; }

    public int? Status { get; set; }

    public int Type { get; set; }

    public DateOnly? DateSent { get; set; }

    public DateOnly? DateReceived { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual User? Customer { get; set; }

    public static implicit operator Booking(List<Booking> v)
    {
        throw new NotImplementedException();
    }
}
