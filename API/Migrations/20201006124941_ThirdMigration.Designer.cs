﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201006124941_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("API.Entities.Flight", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("airlineName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("arrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("departureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("destination")
                        .HasColumnType("TEXT");

                    b.Property<string>("origin")
                        .HasColumnType("TEXT");

                    b.Property<float>("price")
                        .HasColumnType("REAL");

                    b.Property<int>("totalSeats")
                        .HasColumnType("INTEGER");

                    b.HasKey("flightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("hash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("salt")
                        .HasColumnType("BLOB");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
