using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public int? CateId { get; set; }
    public int? UserId { get; set; }

    public string? Report { get; set; }

    public int? Status { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public virtual User? User { get; set; }
}
