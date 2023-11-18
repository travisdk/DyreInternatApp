using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Race> Races { get; set; }


    }
}
