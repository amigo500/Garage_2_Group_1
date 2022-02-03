﻿// <auto-generated />
using System;
using Garage_2_Group_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    [DbContext(typeof(Garage_2_Group_1Context))]
    [Migration("20220202090658_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 6, 57, 556, DateTimeKind.Local).AddTicks(7859),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 6, 58, 556, DateTimeKind.Local).AddTicks(7987),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 6, 59, 556, DateTimeKind.Local).AddTicks(8002),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 0, 556, DateTimeKind.Local).AddTicks(8012),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 1, 556, DateTimeKind.Local).AddTicks(8028),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 2, 556, DateTimeKind.Local).AddTicks(8038),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 3, 556, DateTimeKind.Local).AddTicks(8048),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 4, 556, DateTimeKind.Local).AddTicks(8064),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 5, 556, DateTimeKind.Local).AddTicks(8074),
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
                            ArrivalTime = new DateTime(2022, 2, 2, 10, 7, 6, 556, DateTimeKind.Local).AddTicks(8084),
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