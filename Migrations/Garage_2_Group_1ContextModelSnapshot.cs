﻿// <auto-generated />
using System;
using Garage_2_Group_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    [DbContext(typeof(Garage_2_Group_1Context))]
    partial class Garage_2_Group_1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Garage_2_Group_1.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WheelCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 9, 318, DateTimeKind.Local).AddTicks(5443),
                            Color = 0,
                            Make = "Boeing",
                            Model = "737",
                            RegNr = "AIR001",
                            Type = 0,
                            WheelCount = 6
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 10, 318, DateTimeKind.Local).AddTicks(5477),
                            Color = 1,
                            Make = "SAAB",
                            Model = "JAS 39",
                            RegNr = "AIR00S",
                            Type = 0,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 11, 318, DateTimeKind.Local).AddTicks(5481),
                            Color = 2,
                            Make = "Bertram",
                            Model = "35 Flybridge",
                            RegNr = "WET001",
                            Type = 1,
                            WheelCount = 0
                        },
                        new
                        {
                            Id = 4,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 12, 318, DateTimeKind.Local).AddTicks(5483),
                            Color = 3,
                            Make = "Viking Line",
                            Model = "Cinderella",
                            RegNr = "WET00B",
                            Type = 1,
                            WheelCount = 0
                        },
                        new
                        {
                            Id = 5,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 13, 318, DateTimeKind.Local).AddTicks(5485),
                            Color = 4,
                            Make = "Bridgestone",
                            Model = "U-AP 002",
                            RegNr = "LNG420",
                            Type = 2,
                            WheelCount = 6
                        },
                        new
                        {
                            Id = 6,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 14, 318, DateTimeKind.Local).AddTicks(5487),
                            Color = 5,
                            Make = "Goodyear",
                            Model = "CDOBQ",
                            RegNr = "LNG404",
                            Type = 2,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 7,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 15, 318, DateTimeKind.Local).AddTicks(5490),
                            Color = 6,
                            Make = "Toyota",
                            Model = "RAV4",
                            RegNr = "FST00S",
                            Type = 3,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 8,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 16, 318, DateTimeKind.Local).AddTicks(5492),
                            Color = 7,
                            Make = "Jeep",
                            Model = "Wrangler",
                            RegNr = "FST00T",
                            Type = 3,
                            WheelCount = 4
                        },
                        new
                        {
                            Id = 9,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 17, 318, DateTimeKind.Local).AddTicks(5494),
                            Color = 8,
                            Make = "Yamaha",
                            Model = "YZF R15 V4",
                            RegNr = "SOL006",
                            Type = 4,
                            WheelCount = 2
                        },
                        new
                        {
                            Id = 10,
                            ArrivalTime = new DateTime(2022, 1, 31, 13, 31, 18, 318, DateTimeKind.Local).AddTicks(5496),
                            Color = 9,
                            Make = "Triumph",
                            Model = "Speed Twin",
                            RegNr = "SOL00P",
                            Type = 4,
                            WheelCount = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
