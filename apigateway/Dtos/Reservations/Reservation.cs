﻿using System.ComponentModel.DataAnnotations;
using apigateway.Dtos.TransportOptions;

namespace apigateway.Dtos.Reservations;

public class ReservationHotelRoom
{
    public int Size { get; set; }
    public int Number { get; set; }
}


public class Reservation
{
    public Guid? ToHotelTransportOptionId { get; set; }
    public Guid? FromHotelTransportOptionId { get; set; }
    [Required]
    public Guid HotelId { get; set; }
    
    [Required]
    public int NumberOfAdults { get; set; }
    [Required]
    public int NumberOfUnder3 { get; set; }
    [Required]
    public int NumberOfUnder10 { get; set; }
    [Required]
    public int NumberOfUnder18 { get; set; }
    
    [Required]
    public DateTime DateTime { get; set; }
    
    [Required]
    public int NumberOfNights { get; set; }
    
    [Required]
    public bool FoodIncluded { get; set; }
    
    [Required]
    public IEnumerable<ReservationHotelRoom> Rooms { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string HotelName { get; set; }
    
    [Required]
    public string HotelCity { get; set; }
    
    [Required]
    public string TypeOfTransport { get; set; }
    
    public string? FromCity { get; set; }
    
    [Required]
    public Boolean Finalized { get; set; }
    
    [Required]
    public DateTime ReservedUntil { get; set; }
}