﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace transportservice.Models
{
    public class TransportDbContext : DbContext
    {
        public DbSet<TransportOption> TransportOptions { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<SeatsChange> SeatsChanges { get; set; }

        public TransportDbContext(DbContextOptions<TransportDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransportOption>()
                .HasKey(to => to.Id);

            modelBuilder.Entity<Discount>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Discount>()
                .HasOne<TransportOption>()
                .WithMany(to => to.Discounts)
                .HasForeignKey(d => d.TransportOptionId);

            modelBuilder.Entity<SeatsChange>()
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<SeatsChange>()
                .HasOne<TransportOption>()
                .WithMany(to => to.SeatsChanges)
                .HasForeignKey(sc => sc.TransportOptionId);
            
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
