﻿using System.ComponentModel.DataAnnotations;


namespace apigateway.Dtos.Reservations;

public class RoomInfo
{
    public int Size { get; set; }
    public int Count { get; set; }
}

public class ReservationCreate
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
    public bool FoodIncluded { get; set; }
    
    [Required]
    public IEnumerable<RoomInfo> Rooms { get; set; }
}