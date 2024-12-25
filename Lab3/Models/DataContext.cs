using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<MyUser> MyUsers => Set<MyUser>();
    }
}
