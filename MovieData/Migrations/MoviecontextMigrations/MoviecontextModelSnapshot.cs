﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieData.Models;

namespace MovieData.Migrations.MoviecontextMigrations
{
    [DbContext(typeof(Moviecontext))]
    partial class MoviecontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieData.Models.Movieentity", b =>
                {
                    b.Property<int>("movieid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviebudget")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviecategory1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviecategory2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviedescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movieduration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movielanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movielead1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movielead2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("movierating")
                        .HasColumnType("float");

                    b.Property<int>("movieyear")
                        .HasColumnType("int");

                    b.Property<string>("videotrailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieid");

                    b.ToTable("movieentities");
                });
#pragma warning restore 612, 618
        }
    }
}