using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace reservationservice.Models;
public enum TransportType
{
    Airplane,
    Train,
    Bus
}

public class Reservation
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public int NumAdults { get; init; }
    public int NumUnder3 { get; init; }
    public int NumUnder10 { get; init; }
    public int NumUnder18 { get; init; }
    public Guid ToDestinationTransport { get; init; }
    public List<HotelRoomReservation> HotelRoomReservations { get; init; }
    public Guid FromDestinationTransport { get; init; }
    public bool Finalized { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal Price { get; init; }
    public string ToCity { get; init; }
    public string? FromCity { get; init; }
    public TransportType TransportType { get; init; } // Enum for transport type
    public DateTime? ReservedUntil { get; init; }
    public List<BeingPaidFor>? BeingPaidFors { get; init; }
}

public class HotelRoomReservation
{
    public Guid Id { get; init; }
    public Guid ReservationId { get; init; } // Foreign key property
    public Reservation Reservation { get; init; } // Navigation property
    public Guid HotelRoomReservationObjectId { get; init; }
}

public class BeingPaidFor
{
    public Guid Id { get; init; }
    public Guid ReservationId { get; init; } // Foreign key property
    public Reservation Reservation { get; init; } // Navigation property
    public DateTime? CancellationDate { get; init; }
}