using contracts.Dtos;

namespace hotelservice.Models;

public class Hotel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal FoodPricePerPerson { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Street { get; set; }
    public List<Discount> Discounts { get; set; }
    public List<Room> Rooms { get; set; }
}

public class RoomReservation
{
    public Guid Id { get; set; }
    public Guid RoomsId { get; set; } // Foreign key
    public int RoomsReserved { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime? CancelationDate { get; set; }
}

public class Discount
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; } // Foreign key
    public decimal Value { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class Room
{
    public Guid Id;
    public Guid HotelId; // Foreign key
    public int Size;
    public Decimal Price;
    public int Count;
    public List<RoomReservation> Bookings { get; set; }
}
