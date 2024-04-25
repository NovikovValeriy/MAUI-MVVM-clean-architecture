using Microsoft.EntityFrameworkCore;

namespace _253504Novikov.Persistense.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Garage> Garages { get; set; }
    }
}
