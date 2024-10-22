using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public string? UserAddress { get; set; }

    public DateOnly? CreatedDay { get; set; }

    public DateOnly? UpdateDay { get; set; }

    public virtual ICollection<BlogRepository> BlogCreatedByNavigations { get; set; } = new List<BlogRepository>();

    public virtual ICollection<BlogRepository> BlogUpdateByNavigations { get; set; } = new List<BlogRepository>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CommentBlog> CommentBlogCreatedByNavigations { get; set; } = new List<CommentBlog>();

    public virtual ICollection<CommentBlog> CommentBlogUpdateByNavigations { get; set; } = new List<CommentBlog>();

    public virtual ICollection<CommentKoi> CommentKoiCreatedByNavigations { get; set; } = new List<CommentKoi>();

    public virtual ICollection<CommentKoi> CommentKoiUpdateByNavigations { get; set; } = new List<CommentKoi>();

    public virtual ICollection<CommentNews> CommentNewsCreatedByNavigations { get; set; } = new List<CommentNews>();

    public virtual ICollection<CommentNews> CommentNewsUpdateByNavigations { get; set; } = new List<CommentNews>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<News> NewsCreatedByNavigations { get; set; } = new List<News>();

    public virtual ICollection<News> NewsUpdateByNavigations { get; set; } = new List<News>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
