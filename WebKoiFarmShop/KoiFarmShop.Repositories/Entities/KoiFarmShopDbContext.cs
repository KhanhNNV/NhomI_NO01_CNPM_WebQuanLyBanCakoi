using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories.Entities;

public partial class KoiFarmShopDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public KoiFarmShopDbContext()
    {
    }

    public KoiFarmShopDbContext(DbContextOptions<KoiFarmShopDbContext> options)
        : base(options)
    {
    }

   

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CommentBlog> CommentBlogs { get; set; }

    public virtual DbSet<CommentKoi> CommentKois { get; set; }

    public virtual DbSet<CommentNews> CommentNews { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<KoiCategory> KoiCategories { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=KoiFarmShopDB;Persist Security Info=True;User ID=sa;Password=123@;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__54379E50E7DE9897");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Cate).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__Blog__CateID__14270015");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951AEDEAE4B598");

            entity.ToTable("Booking");

            entity.Property(e => e.Breed).HasMaxLength(32);
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Koiname).HasMaxLength(32);
            entity.Property(e => e.Origin).HasMaxLength(32);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Cate).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__Booking__CateID__4F47C5E3");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B1690CB8F");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(32);
        });

        modelBuilder.Entity<CommentBlog>(entity =>
        {
            entity.HasKey(e => e.CmtBlogId).HasName("PK__CommentB__5D39C724E7802CF4");

            entity.ToTable("CommentBlog");

            entity.Property(e => e.CmtBlogId).HasColumnName("CmtBlogID");
            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Blog).WithMany(p => p.CommentBlogs)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK__CommentBl__BlogI__1332DBDC");
        });

        modelBuilder.Entity<CommentKoi>(entity =>
        {
            entity.HasKey(e => e.CmtKoiId).HasName("PK__CommentK__06D742EA68DD1AE1");

            entity.ToTable("CommentKoi");

            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Koi).WithMany(p => p.CommentKois)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__CommentKo__KoiID__0C85DE4D");
        });

        modelBuilder.Entity<CommentNews>(entity =>
        {
            entity.HasKey(e => e.CmtNewsId).HasName("PK__CommentN__EF677CE326C0260E");

            entity.Property(e => e.CmtNewsId).HasColumnName("CmtNewsID");
            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NewsId).HasColumnName("NewsID");
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.News).WithMany(p => p.CommentNews)
                .HasForeignKey(d => d.NewsId)
                .HasConstraintName("FK__CommentNe__NewsI__0E6E26BF");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259BC3730F7F");

            entity.ToTable("Contact");

            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(0);

            entity.HasOne(d => d.Cate).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__Contact__CateId__3C34F16F");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6DF61507A0E4");

            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

            entity.HasOne(d => d.Koi).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__Discount__KoiId__73BA3083");

            entity.HasOne(d => d.Pro).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK__Discount__ProId__72C60C4A");
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__E03435989DFD3E0B");

            entity.ToTable("Koi");

            entity.Property(e => e.Breed).HasMaxLength(64);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Image)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.KoiCateId).HasColumnName("KoiCateID");
            entity.Property(e => e.Origin).HasMaxLength(64);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.KoiCate).WithMany(p => p.Kois)
                .HasForeignKey(d => d.KoiCateId)
                .HasConstraintName("FK__Koi__KoiCateID__6754599E");
        });

        modelBuilder.Entity<KoiCategory>(entity =>
        {
            entity.HasKey(e => e.KoiCateId).HasName("PK__KoiCateg__01AE527B4B061B71");

            entity.ToTable("KoiCategory");

            entity.Property(e => e.KoiCateId).ValueGeneratedNever();
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.Title).HasMaxLength(32);

            entity.HasOne(d => d.Cate).WithMany(p => p.KoiCategories)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__KoiCatego__CateI__619B8048");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewId).HasName("PK__News__7CC3769E53BAA46E");

            entity.Property(e => e.NewId).HasColumnName("NewID");
            entity.Property(e => e.CateId).HasColumnName("Cate_ID");
            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Image).HasMaxLength(64);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Cate).WithMany(p => p.News)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__News__Cate_ID__0D7A0286");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF3012034B");

            entity.Property(e => e.CreatedDay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ShipAddress).HasMaxLength(64);
            entity.Property(e => e.UpdateDay).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Koi).WithMany(p => p.Orders)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_Order_Koi");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C5EFA8070");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Koi).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__OrderDeta__KoiId__7B5B524B");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__7A672E12");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Promotio__620295901C480AC6");

            entity.ToTable("Promotion");

            entity.Property(e => e.DayEnd).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DayStart).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
