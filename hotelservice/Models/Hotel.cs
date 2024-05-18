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

    public HotelDto ToDto()
    {
        var roomsDictionary = this.Rooms
            .GroupBy(room => room.Size)
            .ToDictionary(
                group => group.Key,
                group => Tuple.Create(group.First().Price, group.Sum(room => room.Count))
            );
        
        return new HotelDto
        {
            Id = this.Id,
            Name = this.Name,
            FoodPricePerPerson = this.FoodPricePerPerson,
            Address = new AddressDto
            {
                City = this.City,
                Country = this.Country,
                Street = this.Street,
                ShowName = this.Name
            },
            Discounts = this.Discounts.Select(discount => discount.ToDto()).ToList(),
            Bookings = this.Rooms
                .SelectMany(room => room.Bookings)
                .Select(booking => booking.ToDto())
                .ToList(),
            Rooms = roomsDictionary
        };
    }
}

public class RoomReservation
{
    public Guid Id { get; set; }
    public Guid RoomsId { get; set; } // Foreign key
    public int RoomsReserved { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime? CancelationDate { get; set; }
    public Room Rooms { get; set; }

    public RoomReservationDto ToDto()
    {
        return new RoomReservationDto
        {
            Id = this.Id,
            Size = this.Rooms.Size,
            Start = this.Start,
            End = this.End,
        };
    }
}

public class Discount
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; } // Foreign key
    public decimal Value { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public DiscountDto ToDto()
    {
        return new DiscountDto
        {
            Id = this.Id,
            Value = this.Value,
            Start = this.Start,
            End = this.End
        };
    }
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

