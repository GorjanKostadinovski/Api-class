﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAppWorkShop.Database;

#nullable disable

namespace MovieAppWorkShop.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20220820084135_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieAppWorkShop.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ThE story Of the singking of the cruiseShip Named The Titanic",
                            Genre = 5,
                            Title = "Titanic",
                            Year = 1997
                        },
                        new
                        {
                            Id = 2,
                            Description = "Italian Mafia",
                            Genre = 9,
                            Title = "The GodFather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 3,
                            Description = "Superhero Movie",
                            Genre = 6,
                            Title = "Avengers:Endgame",
                            Year = 2019
                        },
                        new
                        {
                            Id = 4,
                            Description = "Jackie Chan action comedy",
                            Genre = 3,
                            Title = "RushHour",
                            Year = 1998
                        },
                        new
                        {
                            Id = 5,
                            Description = "Movie about blue aliens",
                            Genre = 6,
                            Title = "Avatar",
                            Year = 2009
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
