using bookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Connections> Connections { get; set; }
    }
}
