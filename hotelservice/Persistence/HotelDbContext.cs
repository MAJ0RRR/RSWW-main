﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace hotelservice.Models
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>()
                .HasOne<Hotel>()
                .WithMany(r => r.Rooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Discount>()
                .HasOne<Hotel>()
                .WithMany(d => d.Discounts)
                .HasForeignKey(d => d.HotelId);

            modelBuilder.Entity<RoomReservation>()
                .HasOne<Room>()
                .WithMany(rr => rr.Bookings)
                .HasForeignKey(rr => rr.RoomsId);

            modelBuilder.Entity<Hotel>()
                .HasKey(h => h.Id);

            modelBuilder.Entity<RoomReservation>()
                .HasKey(rr => rr.Id);

            modelBuilder.Entity<Discount>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Room>()
                .HasKey(r => r.Id);


            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Local ? v.ToUniversalTime() : v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? (v.Value.Kind == DateTimeKind.Local ? v.Value.ToUniversalTime() : v.Value) : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in dateTimeProperties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(dateTimeConverter);
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion(nullableDateTimeConverter);
                    }
                }
            }
        }
    }
}