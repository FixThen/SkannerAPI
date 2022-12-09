﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScannerAPI.Entities;

#nullable disable

namespace ScannerAPI.Migrations
{
    [DbContext(typeof(ScannerDbContext))]
    partial class ScannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScannerAPI.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Karta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ScannerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScannerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ScannerAPI.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("History_List");
                });

            modelBuilder.Entity("ScannerAPI.Entities.Scanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Budynek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Skaner")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.ToTable("Scanners");
                });

            modelBuilder.Entity("ScannerAPI.Entities.Employee", b =>
                {
                    b.HasOne("ScannerAPI.Entities.Scanner", null)
                        .WithMany("Employees")
                        .HasForeignKey("ScannerId");
                });

            modelBuilder.Entity("ScannerAPI.Entities.Scanner", b =>
                {
                    b.HasOne("ScannerAPI.Entities.History", null)
                        .WithMany("Scanners")
                        .HasForeignKey("HistoryId");
                });

            modelBuilder.Entity("ScannerAPI.Entities.History", b =>
                {
                    b.Navigation("Scanners");
                });

            modelBuilder.Entity("ScannerAPI.Entities.Scanner", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
