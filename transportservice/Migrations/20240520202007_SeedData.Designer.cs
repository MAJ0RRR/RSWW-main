﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using transportservice.Models;

#nullable disable

namespace transportservice.Migrations
{
    [DbContext(typeof(TransportDbContext))]
    [Migration("20240520202007_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("transportservice.Models.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TransportOptionId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("TransportOptionId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("transportservice.Models.SeatsChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ChangeBy")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransportOptionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TransportOptionId");

                    b.ToTable("SeatsChanges");
                });

            modelBuilder.Entity("transportservice.Models.TransportOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FromCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FromShowName")
                        .HasColumnType("text");

                    b.Property<string>("FromStreet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InitialSeats")
                        .HasColumnType("integer");

                    b.Property<decimal>("PriceAdult")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToShowName")
                        .HasColumnType("text");

                    b.Property<string>("ToStreet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransportOptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1328aca2-bf3e-4ba0-b684-a39a1da0b5c0"),
                            End = new DateTime(2024, 5, 21, 22, 20, 6, 841, DateTimeKind.Utc).AddTicks(4752),
                            FromCity = "Paris",
                            FromCountry = "France",
                            FromStreet = "Charles de Gaulle",
                            InitialSeats = 100,
                            PriceAdult = 150m,
                            Start = new DateTime(2024, 5, 21, 20, 20, 6, 841, DateTimeKind.Utc).AddTicks(4741),
                            ToCity = "Berlin",
                            ToCountry = "Germany",
                            ToStreet = "Tegel",
                            Type = "Plane"
                        },
                        new
                        {
                            Id = new Guid("0836f771-6dab-4162-a9eb-e036d7fbe740"),
                            End = new DateTime(2024, 5, 26, 1, 20, 6, 841, DateTimeKind.Utc).AddTicks(4761),
                            FromCity = "Berlin",
                            FromCountry = "Germany",
                            FromStreet = "Tegel",
                            InitialSeats = 100,
                            PriceAdult = 150m,
                            Start = new DateTime(2024, 5, 25, 20, 20, 6, 841, DateTimeKind.Utc).AddTicks(4761),
                            ToCity = "Paris",
                            ToCountry = "France",
                            ToStreet = "Charles de Gaulle",
                            Type = "Plane"
                        },
                        new
                        {
                            Id = new Guid("df19951a-99ce-43c9-9a77-44c79ed876ec"),
                            End = new DateTime(2024, 5, 22, 6, 20, 6, 841, DateTimeKind.Utc).AddTicks(4765),
                            FromCity = "Tokyo",
                            FromCountry = "Japan",
                            FromStreet = "Narita",
                            InitialSeats = 150,
                            PriceAdult = 500m,
                            Start = new DateTime(2024, 5, 21, 20, 20, 6, 841, DateTimeKind.Utc).AddTicks(4765),
                            ToCity = "Gdansk",
                            ToCountry = "Poland",
                            ToStreet = "Lech Walesa",
                            Type = "Plane"
                        },
                        new
                        {
                            Id = new Guid("a889c081-5ee8-4e06-9cf6-52c6f9291556"),
                            End = new DateTime(2024, 6, 4, 6, 20, 6, 841, DateTimeKind.Utc).AddTicks(4781),
                            FromCity = "Gdansk",
                            FromCountry = "Poland",
                            FromStreet = "Lech Walesa",
                            InitialSeats = 150,
                            PriceAdult = 500m,
                            Start = new DateTime(2024, 6, 3, 20, 20, 6, 841, DateTimeKind.Utc).AddTicks(4781),
                            ToCity = "Tokyo",
                            ToCountry = "Japan",
                            ToStreet = "Narita",
                            Type = "Plane"
                        },
                        new
                        {
                            Id = new Guid("1c0ec85f-2093-46de-b36b-025e78e9bd1f"),
                            End = new DateTime(2024, 5, 23, 22, 20, 6, 841, DateTimeKind.Utc).AddTicks(4910),
                            FromCity = "London",
                            FromCountry = "UK",
                            FromStreet = "Heathrow",
                            InitialSeats = 120,
                            PriceAdult = 200m,
                            Start = new DateTime(2024, 5, 23, 20, 20, 6, 841, DateTimeKind.Utc).AddTicks(4909),
                            ToCity = "Gdansk",
                            ToCountry = "Poland",
                            ToStreet = "Lech Walesa",
                            Type = "Plane"
                        });
                });

            modelBuilder.Entity("transportservice.Models.Discount", b =>
                {
                    b.HasOne("transportservice.Models.TransportOption", null)
                        .WithMany("Discounts")
                        .HasForeignKey("TransportOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("transportservice.Models.SeatsChange", b =>
                {
                    b.HasOne("transportservice.Models.TransportOption", null)
                        .WithMany("SeatsChanges")
                        .HasForeignKey("TransportOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("transportservice.Models.TransportOption", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("SeatsChanges");
                });
#pragma warning restore 612, 618
        }
    }
}