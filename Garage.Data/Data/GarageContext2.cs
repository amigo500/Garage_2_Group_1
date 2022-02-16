﻿#nullable disable
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

    public DbSet<Vehicle> Vehicle { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<VehicleType> VehicleType { get; set; }
    public DbSet<ParkingSlot> ParkingSlot { get; set; }

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
            .HasData
                (
                    new VehicleType(1, "Airplane", 3),
                    new VehicleType(2, "Boat", 3),
                    new VehicleType(3, "Bus", 2),
                    new VehicleType(4, "Car", 1),
                    new VehicleType(5, "Motorcycle", 1)
                );
    }
}
