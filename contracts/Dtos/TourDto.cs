namespace contracts.Dtos;

public class TourDto
{
    public Guid? ToHotelTransportOptionId { get; set; }

    public Guid? FromHotelTransportOptionId { get; set; }
    public Guid? HotelId { get; set; }
    public string HotelName { get; set; }
    public string HotelCity { get; set; }
    public string TypeOfTransport { get; set; }
    public string? FromCity { get; set; }
    public DateTime DateTime { get; set; }
    public int NumberOfNights { get; set; }

}