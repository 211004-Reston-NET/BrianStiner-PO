using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class revaturedatabaseContext : DbContext
    {
        public revaturedatabaseContext()
        {
        }

        public revaturedatabaseContext(DbContextOptions<revaturedatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersLineitem> OrdersLineitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Storefront> Storefronts { get; set; }
        public virtual DbSet<StorefrontOrder> StorefrontOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer_Orders");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Customer___Custo__0C85DE4D");

                entity.HasOne(d => d.Orders)
                    .WithMany()
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__Customer___Order__0D7A0286");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventory");

                entity.Property(e => e.LineitemId).HasColumnName("Lineitem_ID");

                entity.Property(e => e.StorefrontId).HasColumnName("Storefront_ID");

                entity.HasOne(d => d.Lineitem)
                    .WithMany()
                    .HasForeignKey(d => d.LineitemId)
                    .HasConstraintName("FK__Inventory__Linei__07C12930");

                entity.HasOne(d => d.Storefront)
                    .WithMany()
                    .HasForeignKey(d => d.StorefrontId)
                    .HasConstraintName("FK__Inventory__Store__06CD04F7");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<OrdersLineitem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Orders_Lineitem");

                entity.Property(e => e.LineItemId).HasColumnName("LineItem_ID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.HasOne(d => d.LineItem)
                    .WithMany()
                    .HasForeignKey(d => d.LineItemId)
                    .HasConstraintName("FK__Orders_Li__LineI__0A9D95DB");

                entity.HasOne(d => d.Orders)
                    .WithMany()
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__Orders_Li__Order__09A971A2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Storefront>(entity =>
            {
                entity.ToTable("Storefront");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<StorefrontOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Storefront_Orders");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.Property(e => e.StorefrontId).HasColumnName("Storefront_ID");

                entity.HasOne(d => d.Orders)
                    .WithMany()
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__Storefron__Order__04E4BC85");

                entity.HasOne(d => d.Storefront)
                    .WithMany()
                    .HasForeignKey(d => d.StorefrontId)
                    .HasConstraintName("FK__Storefron__Store__03F0984C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
