using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        string[] roleNames = { "Admin", "Customer" };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
         
     
                modelBuilder.Entity<IdentityRole>()
                  .HasData(new IdentityRole { Id= "a227247c-5650-4b39-b1ad-83f0db7292e2", Name = roleNames[0], NormalizedName = roleNames[0].ToUpper() });
                modelBuilder.Entity<IdentityRole>()
                   .HasData(new IdentityRole { Id = "de450d59-55f6-4bbf-9d3b-2425b46bb861", Name = roleNames[1], NormalizedName = roleNames[1].ToUpper() });


            modelBuilder.Entity<Species>().HasData(
                
                new Species { SpeciesId = 1, SpeciesName = "Hund"},
                new Species { SpeciesId = 2, SpeciesName = "Kat" },
                new Species { SpeciesId = 3, SpeciesName = "Gnaver"},
                new Species { SpeciesId = 4, SpeciesName = "Fugl"}

                );

            modelBuilder.Entity<Race>().HasData(

                 new Race { SpeciesId = 1, RaceId = 1, RaceName = "Bichon Havanais" },
                 new Race { SpeciesId = 1, RaceId = 2, RaceName = "Irsk Setter" },
                 new Race { SpeciesId = 1, RaceId = 3, RaceName = "Gravhund" },
                 new Race { SpeciesId = 1, RaceId = 4, RaceName = "Labrador" },
                 new Race { SpeciesId = 2, RaceId = 5, RaceName = "Ragdoll" },
                 new Race { SpeciesId = 2, RaceId = 6, RaceName = "Perser" },
                 new Race { SpeciesId = 2, RaceId = 7, RaceName = "Cornish Rex" },
                 new Race { SpeciesId = 2, RaceId = 8, RaceName = "Tyrkisk Angora" }
                 );
        }
    }
}
