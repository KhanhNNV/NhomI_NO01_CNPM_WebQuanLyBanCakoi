﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public int? UserId { get; set; }

    public string? Repost { get; set; }

    public int? Status { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public virtual User? User { get; set; }
}