﻿// <auto-generated />
using System;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassLibraryPoultryFarm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220326170202_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageEggsNumber")
                        .HasColumnType("int");

                    b.Property<double>("AverageWeight")
                        .HasColumnType("float");

                    b.Property<string>("BreedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CageNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ChickenId")
                        .HasColumnType("int");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChickenId")
                        .IsUnique()
                        .HasFilter("[ChickenId] IS NOT NULL");

                    b.HasIndex("WorkerId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Chicken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<int>("ChickenAge")
                        .HasColumnType("int");

                    b.Property<double>("ChickenWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("Chickens");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChickenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfEggs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChickenId")
                        .IsUnique();

                    b.ToTable("Production");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfCages")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRows")
                        .HasColumnType("int");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Breed", b =>
                {
                    b.HasOne("ClassLibraryPoultryFarm.Models.Diet", "Diet")
                        .WithMany("Breeds")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Cage", b =>
                {
                    b.HasOne("ClassLibraryPoultryFarm.Models.Chicken", "Chicken")
                        .WithOne("Cage")
                        .HasForeignKey("ClassLibraryPoultryFarm.Models.Cage", "ChickenId");

                    b.HasOne("ClassLibraryPoultryFarm.Models.Worker", "Worker")
                        .WithMany("Cages")
                        .HasForeignKey("WorkerId");

                    b.HasOne("ClassLibraryPoultryFarm.Models.Workshop", "Workshop")
                        .WithMany("Cages")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chicken");

                    b.Navigation("Worker");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Chicken", b =>
                {
                    b.HasOne("ClassLibraryPoultryFarm.Models.Breed", "Breed")
                        .WithMany("Chickens")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Production", b =>
                {
                    b.HasOne("ClassLibraryPoultryFarm.Models.Chicken", "Chicken")
                        .WithOne("Production")
                        .HasForeignKey("ClassLibraryPoultryFarm.Models.Production", "ChickenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chicken");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Worker", b =>
                {
                    b.HasOne("ClassLibraryPoultryFarm.Models.Workshop", "Workshop")
                        .WithMany("Workers")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Breed", b =>
                {
                    b.Navigation("Chickens");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Chicken", b =>
                {
                    b.Navigation("Cage");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Diet", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Worker", b =>
                {
                    b.Navigation("Cages");
                });

            modelBuilder.Entity("ClassLibraryPoultryFarm.Models.Workshop", b =>
                {
                    b.Navigation("Cages");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}