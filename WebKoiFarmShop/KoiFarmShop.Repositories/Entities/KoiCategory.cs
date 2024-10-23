using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities
{
    public partial class KoiCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();
    }
}
