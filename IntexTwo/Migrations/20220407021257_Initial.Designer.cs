﻿// <auto-generated />
using IntexTwo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntexTwo.Migrations
{
    [DbContext(typeof(CrashesDbContext))]
    [Migration("20220407021257_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IntexTwo.Models.CrashModel", b =>
                {
                    b.Property<int>("CRASH_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("BICYCLIST_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CITY")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("COMMERCIAL_MOTOR_VEH_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("COUNTY_NAME")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CRASH_DATETIME")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CRASH_SEVERITY_ID")
                        .HasColumnType("int");

                    b.Property<bool>("DISTRACTED_DRIVING")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DOMESTIC_ANIMAL_RELATED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DROWSY_DRIVING")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DUI")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IMPROPER_RESTRAINT")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("INTERSECTION_RELATED")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("LAT_UTM_Y")
                        .HasColumnType("double");

                    b.Property<double>("LONG_UTM_X")
                        .HasColumnType("double");

                    b.Property<string>("MAIN_ROAD_NAME")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("MILEPOINT")
                        .HasColumnType("double");

                    b.Property<bool>("MOTORCYCLE_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("NIGHT_DARK_CONDITION")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("OLDER_DRIVER_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("OVERTURN_ROLLOVER")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PEDESTRIAN_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ROADWAY_DEPARTURE")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ROUTE")
                        .HasColumnType("int");

                    b.Property<bool>("SINGLE_VEHICLE")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TEENAGE_DRIVER_INVOLVED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("UNRESTRAINED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WILD_ANIMAL_RELATED")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WORK_ZONE_RELATED")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CRASH_ID");

                    b.ToTable("Crashes");
                });
#pragma warning restore 612, 618
        }
    }
}