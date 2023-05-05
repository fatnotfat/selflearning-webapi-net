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
        #endregion
    }
}
