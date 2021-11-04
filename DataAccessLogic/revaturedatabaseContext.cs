using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace DataAccessLogic.Entity
{
    public partial class revaturedatabaseContext : DbContext
    {
        public revaturedatabaseContext() {}

        public revaturedatabaseContext(DbContextOptions<revaturedatabaseContext> options)
            : base(options) {}

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersLineItem> OrdersLineitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Storefronts { get; set; }
        public virtual DbSet<StoreOrder> StorefrontOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.TotalSpent)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("Customer_Orders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer___Custo__2EDAF651");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer___Order__2FCF1A8A");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LineItemId).HasColumnName("Lineitem_ID");

                entity.Property(e => e.StoreId).HasColumnName("Storefront_ID");

                entity.HasOne(d => d.LineItem)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LineItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Linei__282DF8C2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__2739D489");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineItem__Produc__19DFD96B");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<OrdersLineItem>(entity =>
            {
                entity.ToTable("Orders_Lineitem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LineItemId).HasColumnName("LineItem_ID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.HasOne(d => d.LineItem)
                    .WithMany(p => p.OrdersLineitems)
                    .HasForeignKey(d => d.LineItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_Li__LineI__2BFE89A6");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrdersLineItems)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_Li__Order__2B0A656D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Storefront");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Expenses)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("expenses");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Revenue)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("revenue");
            });

            modelBuilder.Entity<StoreOrder>(entity =>
            {
                entity.ToTable("Storefront_Orders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.Property(e => e.StoreId).HasColumnName("Storefront_ID");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Store__Order__339FAB6E");

                entity.HasOne(d => d.Stores)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Store__Store__32AB8735");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
