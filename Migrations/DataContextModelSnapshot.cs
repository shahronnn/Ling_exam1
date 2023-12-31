﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _001Task.Data;

#nullable disable

namespace _001Task.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_001Task.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Population")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "New York",
                            Population = 8623000
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Toronto",
                            Population = 2930000
                        });
                });

            modelBuilder.Entity("_001Task.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Canada"
                        });
                });

            modelBuilder.Entity("_001Task.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Peoples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            CityId = 1,
                            FirstName = "John",
                            LastName = "Mark"
                        },
                        new
                        {
                            Id = 2,
                            Age = 25,
                            CityId = 2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            Age = 35,
                            CityId = 2,
                            FirstName = "Alice",
                            LastName = "Jane"
                        },
                        new
                        {
                            Id = 4,
                            Age = 19,
                            CityId = 1,
                            FirstName = "Mark",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 5,
                            Age = 29,
                            CityId = 1,
                            FirstName = "Malik",
                            LastName = "Malik"
                        },
                        new
                        {
                            Id = 6,
                            Age = 17,
                            CityId = 1,
                            FirstName = "Marks",
                            LastName = "Does"
                        });
                });

            modelBuilder.Entity("_001Task.City", b =>
                {
                    b.HasOne("_001Task.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("_001Task.People", b =>
                {
                    b.HasOne("_001Task.City", "City")
                        .WithMany("Peoples")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("_001Task.City", b =>
                {
                    b.Navigation("Peoples");
                });

            modelBuilder.Entity("_001Task.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
