using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductShop.DataBase
{
    public partial class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions<ProductShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TypeOfPayment> TypeOfPayments { get; set; }
        public virtual DbSet<UserSale> UserSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProductShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsFixedLength(true);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Category_CategoryType");
            });

            modelBuilder.Entity<CategoryType>(entity =>
            {
                entity.ToTable("CategoryType");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Sale).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Order_TypeOfPayment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_Buyer1");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLines_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLines_Product");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateExpiration).HasColumnType("date");

                entity.Property(e => e.DateProduction).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Sale).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Background)
                    .HasMaxLength(1000)
                    .IsFixedLength(true);

                entity.Property(e => e.Condition).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GiveAwayCondition).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Offer).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_ShoppingCart_Buyer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ShoppingCart_Product");
            });

            modelBuilder.Entity<TypeOfPayment>(entity =>
            {
                entity.ToTable("TypeOfPayment");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UserSale>(entity =>
            {
                entity.ToTable("User_Sale");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserSales)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_User_Sale_Order");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.UserSales)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK_User_Sale_Sale");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSales)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Sale_Buyer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
