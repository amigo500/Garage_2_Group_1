#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage.Entities;
using Garage.Entities.Vehicles;

    public class GarageContext2 : DbContext
    {
        public GarageContext2 (DbContextOptions<GarageContext2> options)
            : base(options)
        {
        }

        public DbSet<Garage.Entities.User> User { get; set; }

        public DbSet<Garage.Entities.Vehicles.Vehicle> Vehicle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Vehicle>()
        //            .HasOne(v => v.User)
        //            .WithMany(u => u.Vehicles)
        //            .HasForeignKey(u => u.UserSSN);

        //modelBuilder.Entity<Vehicle>()
        //            .HasOne(v => v.VehicleType)
        //            .WithMany(t => t.Vehicles)
        //            .HasForeignKey(v => v.VehicleTypeID);

        modelBuilder.Entity<VehicleType>()
            .HasData(new VehicleType
            {
                Id = 1,
                Name = "Airplane",
                Size = 3,
            },
            new VehicleType
            {
                Id = 2,
                Name = "Boat",
                Size = 3,
            },
            new VehicleType
            {
                Id = 3,
                Name = "Bus",
                Size = 2,
            },
            new VehicleType
            {
                Id = 4,
                Name = "Car",
                Size = 1,
            },
            new VehicleType
            {
                Id = 5,
                Name = "Motorcycle",
                Size = 1,
            });
    }
}
