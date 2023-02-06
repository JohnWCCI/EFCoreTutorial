﻿// <auto-generated />
using EFCoreTutorial.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreTutorial.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20230206000209_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreTutorial.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Johnny",
                            LastName = "Cash"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jimmy",
                            LastName = "Buffet"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Home",
                            LastName = "Free"
                        });
                });

            modelBuilder.Entity("EFCoreTutorial.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            Title = "Your Heartless"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 1,
                            Title = "Ride Bikes"
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 1,
                            Title = "Your Heartless"
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 1,
                            Title = "Wayfaring Stranger"
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 2,
                            Title = "Son of a Sailor"
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 3,
                            Title = "Sea Shanty"
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 2,
                            Title = "Island"
                        });
                });

            modelBuilder.Entity("EFCoreTutorial.Models.Song", b =>
                {
                    b.HasOne("EFCoreTutorial.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("EFCoreTutorial.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}