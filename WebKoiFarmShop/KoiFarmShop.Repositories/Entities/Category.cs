using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities
{
    public partial class Category
    {
        public int CateId { get; set; } // ID của danh mục
        public string CateName { get; set; } = null!; // Tên danh mục
        public string? Description { get; set; } // Mô tả danh mục
        public DateTime CreatedDay { get; set; } // Ngày tạo
        public DateTime? UpdateDay { get; set; } // Ngày cập nhật (nếu có)

        // Liên kết đến danh sách Koi
        public virtual ICollection<Koi> Koi { get; set; } = new List<Koi>();
    }
}
