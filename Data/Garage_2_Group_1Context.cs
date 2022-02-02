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
                        RegNr = "AIR001",
                        Type = VehicleType.Airplane,
                        Color = VehicleColor.Blue,
                        ArrivalTime = DateTime.Now,
                        Make = "Boeing",
                        Model = "737",
                        WheelCount = 6
                    },
                    new Vehicle
                    {
                        Id = 2,
                        RegNr = "AIR00S",
                        Type = VehicleType.Airplane,
                        Color = VehicleColor.Red,
                        ArrivalTime = DateTime.Now.AddSeconds(1),
                        Make = "SAAB",
                        Model = "JAS 39",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 3,
                        RegNr = "WET001",
                        Type = VehicleType.Boat,
                        Color = VehicleColor.Green,
                        ArrivalTime = DateTime.Now.AddSeconds(2),
                        Make = "Bertram",
                        Model = "35 Flybridge",
                        WheelCount = 0
                    },
                    new Vehicle
                    {
                        Id = 4,
                        RegNr = "WET00B",
                        Type = VehicleType.Boat,
                        Color = VehicleColor.Black,
                        ArrivalTime = DateTime.Now.AddSeconds(3),
                        Make = "Viking Line",
                        Model = "Cinderella",
                        WheelCount = 0
                    },
                    new Vehicle
                    {
                        Id = 5,
                        RegNr = "LNG420",
                        Type = VehicleType.Bus,
                        Color = VehicleColor.White,
                        ArrivalTime = DateTime.Now.AddSeconds(4),
                        Make = "Bridgestone",
                        Model = "U-AP 002",
                        WheelCount = 6
                    },
                    new Vehicle
                    {
                        Id = 6,
                        RegNr = "LNG404",
                        Type = VehicleType.Bus,
                        Color = VehicleColor.Silver,
                        ArrivalTime = DateTime.Now.AddSeconds(5),
                        Make = "Goodyear",
                        Model = "CDOBQ",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 7,
                        RegNr = "FST00S",
                        Type = VehicleType.Car,
                        Color = VehicleColor.Brown,
                        ArrivalTime = DateTime.Now.AddSeconds(6),
                        Make = "Toyota",
                        Model = "RAV4",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 8,
                        RegNr = "FST00T",
                        Type = VehicleType.Car,
                        Color = VehicleColor.Yellow,
                        ArrivalTime = DateTime.Now.AddSeconds(7),
                        Make = "Jeep",
                        Model = "Wrangler",
                        WheelCount = 4
                    },
                    new Vehicle
                    {
                        Id = 9,
                        RegNr = "SOL006",
                        Type = VehicleType.Motorcycle,
                        Color = VehicleColor.Orange,
                        ArrivalTime = DateTime.Now.AddSeconds(8),
                        Make = "Yamaha",
                        Model = "YZF R15 V4",
                        WheelCount = 2
                    },
                    new Vehicle
                    {
                        Id = 10,
                        RegNr = "SOL00P",
                        Type = VehicleType.Motorcycle,
                        Color = VehicleColor.Purple,
                        ArrivalTime = DateTime.Now.AddSeconds(9),
                        Make = "Triumph",
                        Model = "Speed Twin",
                        WheelCount = 2
                    }
                );
        }
    }
}
