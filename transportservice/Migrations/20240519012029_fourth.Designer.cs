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
    [Migration("20240519012029_fourth")]
    partial class fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("transportservice.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShowName")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

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

                    b.Property<Guid>("FromAddressId")
                        .HasColumnType("uuid");

                    b.Property<int>("InitialSeats")
                        .HasColumnType("integer");

                    b.Property<decimal>("PriceAdult")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ToAddressId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ToAddressId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FromAddressId");

                    b.HasIndex("ToAddressId");

                    b.HasIndex("ToAddressId1");

                    b.ToTable("TransportOptions");
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
                    b.HasOne("transportservice.Models.Address", "FromAddress")
                        .WithMany()
                        .HasForeignKey("FromAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("transportservice.Models.Address", null)
                        .WithMany("TransportOptions")
                        .HasForeignKey("ToAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("transportservice.Models.Address", "ToAddress")
                        .WithMany()
                        .HasForeignKey("ToAddressId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAddress");

                    b.Navigation("ToAddress");
                });

            modelBuilder.Entity("transportservice.Models.Address", b =>
                {
                    b.Navigation("TransportOptions");
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
