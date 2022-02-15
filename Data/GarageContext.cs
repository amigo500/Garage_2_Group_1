#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage.Entities.Vehicles;
using Garage.Entities;

namespace Garage_2_Group_1.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<VehicleType> VehicleType { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                        .HasOne(v => v.User)
                        .WithMany(u => u.Vehicles)
                        .HasForeignKey(u => u.UserSSN);

            modelBuilder.Entity<Vehicle>()
                        .HasOne(v => v.VehicleType)
                        .WithMany(t => t.Vehicles)
                        .HasForeignKey(v => v.VehicleTypeID);
              
        }
    }
}