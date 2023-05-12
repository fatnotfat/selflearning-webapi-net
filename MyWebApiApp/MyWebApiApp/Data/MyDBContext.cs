using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options): base(options) {
        }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderID);
                e.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(o => o.Consignee).IsRequired().HasMaxLength(100);
                
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => new {e.OrderID, e.ProductID});

                e.HasOne(o => o.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderID)
                .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(o => o.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.ProductID)
                .HasConstraintName("FK_OrderDetail_Product");
            });
        }
    }
}
