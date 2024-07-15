using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Add DbSet properties for your tables here
        // Example:
        // public DbSet<MyTable> MyTables { get; set; }
    }
}
