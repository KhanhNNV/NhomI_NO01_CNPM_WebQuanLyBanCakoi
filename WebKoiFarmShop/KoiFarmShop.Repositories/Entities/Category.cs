using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<KoiCategory> KoiCategories { get; set; } = new List<KoiCategory>();

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
