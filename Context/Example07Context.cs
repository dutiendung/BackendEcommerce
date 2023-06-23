using Microsoft.EntityFrameworkCore;
namespace Example07.Models;
public partial class Example07Context : DbContext
{
    public Example07Context()
    {
    }
    public Example07Context(DbContextOptions<Example07Context> options)
    : base(options)
    {
    }
    public virtual DbSet<Banner> Banners { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Coupon> Coupons { get; set; }
    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<PostCategory> PostCategories { get; set; }
    public virtual DbSet<PostComment> PostComments { get; set; }
    public virtual DbSet<PostTag> PostTags { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductReview> ProductReviews { get; set; }
    public virtual DbSet<Setting> Settings { get; set; }
    public virtual DbSet<Shipping> Shippings { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Wishlist> Wishlists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_banners_id");
            entity.ToTable("banners");
            entity.HasIndex(e => e.Slug,
    "banners$banners_slug_unique").IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'inactive')")
     .HasColumnName("status");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Brand>(entity =>
    {
        entity.HasKey(e => e.Id).HasName("PK_brands_id");
        entity.ToTable("brands");
        entity.HasIndex(e => e.Slug,
       "brands$brands_slug_unique").IsUnique();
        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.CreatedAt)
        .HasColumnType("datetime")
        .HasColumnName("created_at");
        entity.Property(e => e.Slug)
        .HasMaxLength(191)
        .HasColumnName("slug");
        entity.Property(e => e.Status)
        .HasMaxLength(8)
        .HasDefaultValueSql("(N'active')")
        .HasColumnName("status");
        entity.Property(e => e.Title)
        .HasMaxLength(191)
        .HasColumnName("title");
        entity.Property(e => e.UpdatedAt)
        .HasColumnType("datetime")
        .HasColumnName("updated_at");
    });
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_carts_id");
            entity.ToTable("carts");
            entity.HasIndex(e => e.OrderId, "carts_order_id_foreign");
            entity.HasIndex(e => e.ProductId, "carts_product_id_foreign");
            entity.HasIndex(e => e.UserId, "carts_user_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
     .HasMaxLength(9)
     .HasDefaultValueSql("(N'new')")
     .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Order).WithMany(p => p.Carts)
     .HasForeignKey(d => d.OrderId)
     .HasConstraintName("carts$carts_order_id_foreign");


            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("carts$carts_product_id_foreign");
            entity.HasOne(d => d.User).WithMany(p => p.Carts)
     .HasForeignKey(d => d.UserId)
     .OnDelete(DeleteBehavior.Cascade)
     .HasConstraintName("carts$carts_user_id_foreign");
        });
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_categories_id");
            entity.ToTable("categories");
            entity.HasIndex(e => e.Slug,
    "categories$categories_slug_unique").IsUnique();
            entity.HasIndex(e => e.AddedBy, "categories_added_by_foreign");
            entity.HasIndex(e => e.ParentId, "categories_parent_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy).HasColumnName("added_by");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.IsParent)
     .HasDefaultValueSql("((1))")
     .HasColumnName("is_parent");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'inactive')")
     .HasColumnName("status");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.HasOne(d => d.AddedByNavigation).WithMany(p =>
    p.Categories)
     .HasForeignKey(d => d.AddedBy)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("categories$categories_added_by_foreign");
            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
     .HasForeignKey(d => d.ParentId)
     .HasConstraintName("categories$categories_parent_id_foreign");
        });
        modelBuilder.Entity<Coupon>(entity =>

    {
        entity.HasKey(e => e.Id).HasName("PK_coupons_id");
        entity.ToTable("coupons");
        entity.HasIndex(e => e.Code,
       "coupons$coupons_code_unique").IsUnique();
        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Code)
        .HasMaxLength(191)
        .HasColumnName("code");
        entity.Property(e => e.CreatedAt)
        .HasColumnType("datetime")
        .HasColumnName("created_at");
        entity.Property(e => e.Status)
        .HasMaxLength(8)
        .HasDefaultValueSql("(N'inactive')")
        .HasColumnName("status");
        entity.Property(e => e.Type)
        .HasMaxLength(7)
        .HasDefaultValueSql("(N'fixed')")
        .HasColumnName("type");
        entity.Property(e => e.UpdatedAt)
        .HasColumnType("datetime")
        .HasColumnName("updated_at");
        entity.Property(e => e.Value)
        .HasColumnType("decimal(20, 2)")
        .HasColumnName("value");
    });
        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_failed_jobs_id");
            entity.ToTable("failed_jobs");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection).HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
     .HasDefaultValueSql("(getdate())")
     .HasColumnType("datetime")
     .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
        });
        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_messages_id");
            entity.ToTable("messages");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Email)
     .HasMaxLength(191)
     .HasColumnName("email");
            entity.Property(e => e.Messages).HasColumnName("message");
            entity.Property(e => e.Name)
     .HasMaxLength(191)
        .HasColumnName("name");
            entity.Property(e => e.Phone)
     .HasMaxLength(191)
     .HasColumnName("phone");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.ReadAt)
     .HasColumnType("datetime")
     .HasColumnName("read_at");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_notifications_id");
            entity.ToTable("notifications");
            entity.HasIndex(e => new { e.NotifiableType, e.NotifiableId },
    "notifications_notifiable_type_notifiable_id_index");
            entity.Property(e => e.Id)
     .HasMaxLength(36)
     .IsFixedLength()
     .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e =>
    e.NotifiableId).HasColumnName("notifiable_id");
            entity.Property(e => e.NotifiableType)
     .HasMaxLength(191)
     .HasColumnName("notifiable_type");
            entity.Property(e => e.ReadAt)
     .HasColumnType("datetime")
     .HasColumnName("read_at");
            entity.Property(e => e.Type)
     .HasMaxLength(191)
     .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_orders_id");
            entity.ToTable("orders");
            entity.HasIndex(e => e.OrderNumber,
    "orders$orders_order_number_unique").IsUnique();
            entity.HasIndex(e => e.ShippingId, "orders_shipping_id_foreign");
            entity.HasIndex(e => e.UserId, "orders_user_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1).HasColumnName("address1");


            entity.Property(e => e.Address2).HasColumnName("address2");
            entity.Property(e => e.Country)
     .HasMaxLength(191)
     .HasColumnName("country");
            entity.Property(e => e.Coupon)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("coupon");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Email)
     .HasMaxLength(191)
     .HasColumnName("email");
            entity.Property(e => e.FirstName)
     .HasMaxLength(191)
     .HasColumnName("first_name");
            entity.Property(e => e.LastName)
     .HasMaxLength(191)
     .HasColumnName("last_name");
            entity.Property(e => e.OrderNumber)
     .HasMaxLength(191)
     .HasColumnName("order_number");
            entity.Property(e => e.PaymentMethod)
     .HasMaxLength(6)
     .HasDefaultValueSql("(N'cod')")
     .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
     .HasMaxLength(6)
     .HasDefaultValueSql("(N'unpaid')")
     .HasColumnName("payment_status");
            entity.Property(e => e.Phone)
     .HasMaxLength(191)
     .HasColumnName("phone");
            entity.Property(e => e.PostCode)
     .HasMaxLength(191)
     .HasColumnName("post_code");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShippingId).HasColumnName("shipping_id");
            entity.Property(e => e.Status)
     .HasMaxLength(9)
     .HasDefaultValueSql("(N'new')")
     .HasColumnName("status");
            entity.Property(e => e.SubTotal)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("sub_total");
            entity.Property(e => e.TotalAmount)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Shipping).WithMany(p => p.Orders)
     .HasForeignKey(d => d.ShippingId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("orders$orders_shipping_id_foreign");
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
     .HasForeignKey(d => d.UserId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("orders$orders_user_id_foreign");
        });
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_posts_id");
            entity.ToTable("posts");
            entity.HasIndex(e => e.Slug,
    "posts$posts_slug_unique").IsUnique();
            entity.HasIndex(e => e.AddedBy, "posts_added_by_foreign");
            entity.HasIndex(e => e.PostCatId, "posts_post_cat_id_foreign");
            entity.HasIndex(e => e.PostTagId, "posts_post_tag_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy).HasColumnName("added_by");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.PostCatId).HasColumnName("post_cat_id");
            entity.Property(e => e.PostTagId).HasColumnName("post_tag_id");
            entity.Property(e => e.Quote).HasColumnName("quote");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Tags)
     .HasMaxLength(191)
     .HasColumnName("tags");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Posts)
            .HasForeignKey(d => d.AddedBy)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("posts$posts_added_by_foreign");
            entity.HasOne(d => d.PostCat).WithMany(p => p.Posts)
     .HasForeignKey(d => d.PostCatId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("posts$posts_post_cat_id_foreign");
            entity.HasOne(d => d.PostTag).WithMany(p => p.Posts)
     .HasForeignKey(d => d.PostTagId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("posts$posts_post_tag_id_foreign");
        });
        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_post_categories_id");
            entity.ToTable("post_categories");
            entity.HasIndex(e => e.Slug,
    "post_categories$post_categories_slug_unique").IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_post_comments_id");
            entity.ToTable("post_comments");
            entity.HasIndex(e => e.PostId, "post_comments_post_id_foreign");
            entity.HasIndex(e => e.UserId, "post_comments_user_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e =>
    e.RepliedComment).HasColumnName("replied_comment");
            entity.Property(e => e.Status)

        .HasMaxLength(8)
        .HasDefaultValueSql("(N'active')")
        .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
     .HasForeignKey(d => d.PostId)

    .HasConstraintName("post_comments$post_comments_post_id_foreign");
            entity.HasOne(d => d.User).WithMany(p => p.PostComments)
     .HasForeignKey(d => d.UserId)
     .OnDelete(DeleteBehavior.SetNull)

    .HasConstraintName("post_comments$post_comments_user_id_foreign");
        });
        modelBuilder.Entity<PostTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_post_tags_id");
            entity.ToTable("post_tags");
            entity.HasIndex(e => e.Slug,
    "post_tags$post_tags_slug_unique").IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_products_id");
            entity.ToTable("products");
            entity.HasIndex(e => e.Slug,
    "products$products_slug_unique").IsUnique();
            entity.HasIndex(e => e.BrandId, "products_brand_id_foreign");
            entity.HasIndex(e => e.CatId, "products_cat_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.ChildCatId).HasColumnName("child_cat_id");
            entity.Property(e => e.Condition)
     .HasMaxLength(7)
     .HasDefaultValueSql("(N'default')")
     .HasColumnName("condition");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount)
     .HasColumnType("decimal(20, 2)")
     .HasColumnName("discount");
            entity.Property(e => e.IsFeatured).HasColumnName("is_featured");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Price)
     .HasColumnType("decimal(20, 2)")
     .HasColumnName("price");
            entity.Property(e => e.Size)
     .HasMaxLength(191)
     .HasDefaultValueSql("(N'M')")
     .HasColumnName("size");
            entity.Property(e => e.Slug)
     .HasMaxLength(191)
     .HasColumnName("slug");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'inactive')")
     .HasColumnName("status");
            entity.Property(e => e.Stock)
     .HasDefaultValueSql("((1))")
     .HasColumnName("stock");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Title)
     .HasMaxLength(191)
     .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
     .HasForeignKey(d => d.BrandId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("products$products_brand_id_foreign");
            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
     .HasForeignKey(d => d.CatId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("products$products_cat_id_foreign");
        });
        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_product_reviews_id");
            entity.ToTable("product_reviews");
            entity.HasIndex(e => e.ProductId,
    "product_reviews_product_id_foreign");
            entity.HasIndex(e => e.UserId, "product_reviews_user_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
        .HasColumnName("created_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Review).HasColumnName("review");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
     .HasForeignKey(d => d.ProductId)

    .HasConstraintName("product_reviews$product_reviews_product_id_foreign");
            entity.HasOne(d => d.User).WithMany(p => p.ProductReviews)
     .HasForeignKey(d => d.UserId)
     .OnDelete(DeleteBehavior.SetNull)

    .HasConstraintName("product_reviews$product_reviews_user_id_foreign");
        });
        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_settings_id");
            entity.ToTable("settings");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
     .HasMaxLength(191)
     .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email)
     .HasMaxLength(191)
     .HasColumnName("email");
            entity.Property(e => e.Logo)
     .HasMaxLength(191)
     .HasColumnName("logo");
            entity.Property(e => e.Phone)
     .HasMaxLength(191)
     .HasColumnName("phone");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.ShortDes).HasColumnName("short_des");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_shippings_id");
            entity.ToTable("shippings");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");
            entity.Property(e => e.Price)
     .HasColumnType("decimal(8, 2)")
     .HasColumnName("price");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.Type)
     .HasMaxLength(191)
     .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users_id");
            entity.ToTable("users");
            entity.HasIndex(e => e.Email,
    "users$users_email_unique").IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Email)
     .HasMaxLength(191)
     .HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt)
     .HasColumnType("datetime")
     .HasColumnName("email_verified_at");
            entity.Property(e => e.Name)
     .HasMaxLength(191)
     .HasColumnName("name");
            entity.Property(e => e.Password)
     .HasMaxLength(191)
     .HasColumnName("password");
            entity.Property(e => e.Photo)
     .HasMaxLength(191)
     .HasColumnName("photo");
            entity.Property(e => e.Provider)
     .HasMaxLength(191)
     .HasColumnName("provider");
            entity.Property(e => e.ProviderId)
     .HasMaxLength(191)
     .HasColumnName("provider_id");
            entity.Property(e => e.RememberToken)
     .HasMaxLength(100)
     .HasColumnName("remember_token");
            entity.Property(e => e.Role)
     .HasMaxLength(5)
     .HasDefaultValueSql("(N'user')")
     .HasColumnName("role");
            entity.Property(e => e.Status)
     .HasMaxLength(8)
     .HasDefaultValueSql("(N'active')")
     .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)

        .HasColumnType("datetime")
        .HasColumnName("updated_at");
        });
        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_wishlists_id");
            entity.ToTable("wishlists");
            entity.HasIndex(e => e.CartId, "wishlists_cart_id_foreign");
            entity.HasIndex(e => e.ProductId, "wishlists_product_id_foreign");
            entity.HasIndex(e => e.UserId, "wishlists_user_id_foreign");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("amount");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CreatedAt)
     .HasColumnType("datetime")
     .HasColumnName("created_at");
            entity.Property(e => e.Price)
     .HasColumnType("numeric(8, 2)")
     .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
     .HasColumnType("datetime")
     .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Cart).WithMany(p => p.Wishlists)
     .HasForeignKey(d => d.CartId)
     .HasConstraintName("wishlists$wishlists_cart_id_foreign");
            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
     .HasForeignKey(d => d.ProductId)
     .OnDelete(DeleteBehavior.ClientSetNull)
     .HasConstraintName("wishlists$wishlists_product_id_foreign");
            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
     .HasForeignKey(d => d.UserId)
     .OnDelete(DeleteBehavior.SetNull)
     .HasConstraintName("wishlists$wishlists_user_id_foreign");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
