using contracts.Dtos;

namespace transportservice.Models;

public class TransportOption
{
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Decimal PriceAdult { get; set; }
    public string Type { get; set; }
    public int InitialSeats { get; set; }
    public string FromCity { get; set; }
    public string FromCountry { get; set; }
    public string FromStreet { get; set; }
    public string? FromShowName { get; set; }
    public string ToCity { get; set; }
    public string ToCountry { get; set; }
    public string ToStreet { get; set; }
    public string? ToShowName { get; set; }
    public List<Discount> Discounts { get; set; } = new List<Discount>();
    public List<SeatsChange> SeatsChanges { get; set; }

    public TransportOptionDto ToDto()
    {
        return new TransportOptionDto
        {
            Id = this.Id,
            SeatsAvailable = this.InitialSeats,
            Start = this.Start,
            End = this.End,
            PriceAdult = this.PriceAdult,
            PriceUnder3 = PriceAdult * (decimal)0.1,
            PriceUnder10 = PriceAdult * (decimal)0.5,
            PriceUnder18 = PriceAdult * (decimal)0.9,
            Type = this.Type,
            From = new AddressDto
            {
                Street = this.FromStreet,
                City = this.FromCity,
                Country = this.FromCountry,
                ShowName = this.FromShowName
            },
            To = new AddressDto
            {
                Street = this.ToStreet,
                City = this.ToCity,
                Country = this.ToCountry,
                ShowName = this.ToShowName
            }
        };
    }
}
public class Discount
{
    public Guid Id { get; set; }
    public Guid TransportOptionId { get; set; } // Foreign key
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

public class SeatsChange
{
    public Guid Id { get; set; }
    public Guid TransportOptionId { get; set; } // Foreign Key
    public int ChangeBy { get; set; }
}