﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleFind.MigrationBate.DatabaseContext;

namespace VehicleFind_MigrationBait.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191008193631_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("VehicleFind.MigrationBate.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellNumber");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}