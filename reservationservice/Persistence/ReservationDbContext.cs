using Microsoft.EntityFrameworkCore;
using reservationservice.Models;

namespace reservationservice.Persistence;

public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<HotelRoomReservation> HotelRoomReservations { get; set; }
    public DbSet<BeingPaidFor> BeingPaidFors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Reservation>()
            .HasMany(r => r.HotelRoomReservations)
            .WithOne(hr => hr.Reservation)
            .HasForeignKey(hr => hr.ReservationId);

        modelBuilder.Entity<Reservation>()
            .HasMany(r => r.BeingPaidFors)
            .WithOne(bp => bp.Reservation)
            .HasForeignKey(bp => bp.ReservationId);

        modelBuilder.Entity<HotelRoomReservation>()
            .HasKey(hr => hr.Id);

        modelBuilder.Entity<BeingPaidFor>()
            .HasKey(bp => bp.Id);

        modelBuilder.Entity<Reservation>()
            .Property(r => r.TransportType)
            .HasConversion<string>(); // Store enum as string
    }
}