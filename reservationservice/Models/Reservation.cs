using System;
using System.Collections.Generic;
using contracts.Dtos;

namespace reservationservice.Models;


public class Reservation
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public int NumAdults { get; init; }
    public int NumUnder3 { get; init; }
    public int NumUnder10 { get; init; }
    public int NumUnder18 { get; init; }
    public Guid ToDestinationTransport { get; init; }
    public Guid HotelId { get; init; }
    public List<HotelRoomReservation> HotelRoomReservations { get; init; } = new();
    public Guid FromDestinationTransport { get; init; }
    public bool Finalized { get; set; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal Price { get; init; }
    public string ToCity { get; init; }
    public string? FromCity { get; init; }
    public string TransportType { get; init; }
    public DateTime? ReservedUntil { get; init; }
    
    public DateTime? CancellationDate { get; set; }
    public List<BeingPaidFor> BeingPaidFors { get; init; } = new List<BeingPaidFor>();
    
    public ReservationDto ToDto()
    {
        return new ReservationDto
        {
            Id = this.Id,
            UserId = this.UserId,
            NumAdults = this.NumAdults,
            NumUnder3 = this.NumUnder3,
            NumUnder10 = this.NumUnder10,
            NumUnder18 = this.NumUnder18,
            ToDestinationTransport = this.ToDestinationTransport,
            HotelId = this.HotelId,
            HotelRoomReservations = this.HotelRoomReservations.Select(hr => hr.Id).ToList(),
            FromDestinationTransport = this.FromDestinationTransport,
            Finalized = this.Finalized,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
            Price = this.Price,
            ToCity = this.ToCity,
            FromCity = this.FromCity,
            TransportType = this.TransportType,
            CancellationDate = this.CancellationDate,
            ReservedUntil = this.ReservedUntil
        };
    }
}

public class HotelRoomReservation
{
    public Guid Id { get; init; }
    public Guid ReservationId { get; init; } // Foreign key property
    public Guid HotelRoomReservationObjectId { get; init; }
}

public class BeingPaidFor
{
    public Guid Id { get; init; }
    public Guid ReservationId { get; init; } // Foreign key property
    public DateTime? CancellationDate { get; set; }
}