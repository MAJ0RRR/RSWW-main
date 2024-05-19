namespace contracts.Dtos;


public class ReservationHotelRoom
{
    public int Size { get; set; }
    public int Number { get; set; }
}
public class ReservationDto
{
    public Guid Id { get; set; }
    public Guid? ToHotelTransportOptionId { get; set; }
    public Guid? FromHotelTransportOptionId { get; set; }
    public Guid HotelId { get; set; }
    public int NumberOfAdults { get; set; }
    public int NumberOfUnder3 { get; set; }
    public int NumberOfUnder10 { get; set; }
    public int NumberOfUnder18 { get; set; }
    public DateTime DateTime { get; set; }
    public int NumberOfNights { get; set; }
    public bool FoodIncluded { get; set; }
    public IEnumerable<ReservationHotelRoom> Rooms { get; set; }
    public decimal Price { get; set; }
    public string HotelName { get; set; }
    public string HotelCity { get; set; }
    public string TypeOfTransport { get; set; }
    public string? FromCity { get; set; }
    public Boolean Finalized { get; set; }
    public DateTime ReservedUntil { get; set; }
    public DateTime? CancellationDate { get; set; }
}






