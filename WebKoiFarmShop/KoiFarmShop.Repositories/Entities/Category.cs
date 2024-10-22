using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<BlogRepository> Blogs { get; set; } = new List<BlogRepository>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<KoiCategory> KoiCategories { get; set; } = new List<KoiCategory>();

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
