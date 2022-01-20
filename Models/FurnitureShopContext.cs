using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class FurnitureShopContext : DbContext
    {
        public FurnitureShopContext()
        {
        }

        public FurnitureShopContext(DbContextOptions<FurnitureShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<ImportDetail> ImportDetails { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FurnitureShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discription)
                    .HasMaxLength(255)
                    .HasColumnName("discription");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .HasColumnName("displayname");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.EndAt)
                    .HasColumnType("datetime")
                    .HasColumnName("endAt");

                entity.Property(e => e.IsMoney).HasColumnName("isMoney");

                entity.Property(e => e.MaxValue)
                    .HasColumnType("money")
                    .HasColumnName("maxValue");

                entity.Property(e => e.MinPurchase)
                    .HasColumnType("money")
                    .HasColumnName("minPurchase");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.StartAt)
                    .HasColumnType("datetime")
                    .HasColumnName("startAt");
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.ToTable("import");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.ToTable("import_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.ImportId).HasColumnName("import_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ImportId)
                    .HasConstraintName("FK__import_de__impor__403A8C7D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__import_de__produ__412EB0B6");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("create_at");

                entity.Property(e => e.DeliveryStatus)
                    .HasMaxLength(255)
                    .HasColumnName("delivery_status");

                entity.Property(e => e.DiscountId).HasColumnName("discount_id");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(255)
                    .HasColumnName("payment_status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__invoice__discoun__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__invoice__user_id__3D5E1FD2");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("invoice_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK__invoice_d__invoi__4222D4EF");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__invoice_d__produ__4316F928");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Discription)
                    .HasMaxLength(255)
                    .HasColumnName("discription");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Material)
                    .HasMaxLength(255)
                    .HasColumnName("material");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasMaxLength(255)
                    .HasColumnName("size");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__product__brand_i__3B75D760");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__3C69FB99");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__rating__product___3A81B327");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__rating__user_id__398D8EEE");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discription)
                    .HasMaxLength(255)
                    .HasColumnName("discription");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Discription)
                    .HasMaxLength(255)
                    .HasColumnName("discription");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .HasColumnName("displayname");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__topic__category___3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
