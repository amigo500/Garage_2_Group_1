#nullable disable
using Microsoft.EntityFrameworkCore;
using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Data
{
    public class Garage_2_Group_1Context : DbContext
    {
        public Garage_2_Group_1Context (DbContextOptions<Garage_2_Group_1Context> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasData(
                    new Vehicle 
                    { 
                        Id = 1,
                        RegNr = "ABC123",
                        Type = 0,
                        Color = 0,
                        ArrivalTime = DateTime.Now,
                        Make = "Toyota",
                        Model = "2H4EZ",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 2,
                        RegNr = "ABC12D",
                        Type = 0,
                        Color = 0,
                        ArrivalTime = DateTime.Now,
                        Make = "Honda",
                        Model = "PCD3Y",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 3,
                        RegNr = "AIR001",
                        Type = 0,
                        Color = 0,
                        ArrivalTime = DateTime.Now,
                        Make = "Ford",
                        Model = "68R99",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 4,
                        RegNr = "WET696",
                        Type = 0,
                        Color = 0,
                        ArrivalTime = DateTime.Now,
                        Make = "Jeep",
                        Model = "CDOBQ",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 5,
                        RegNr = "BAN420",
                        Type = 0,
                        Color = 0,
                        ArrivalTime = DateTime.Now,
                        Make = "BMW",
                        Model = "GMKJM",
                        WheelCount = 4
                    }
                );
        }
    }
}
