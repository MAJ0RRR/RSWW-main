using contracts.Dtos;

namespace transportservice.Models;

public class TransportOption
{
    public Guid Id { get; set; }
    public Guid ToAddressId { get; set; } // Foreign Key
    public Guid FromAddressId { get; set; } // Foreign Key
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Decimal PriceAdult { get; set; }
    public string Type { get; set; }
    public int InitialSeats { get; set; }
    public Address FromAddress { get; set; }
    public Address ToAddress { get; set; }
    public List<Discount> Discounts { get; set; }
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
                Street = this.FromAddress.Street,
                City = this.FromAddress.City,
                Country = this.FromAddress.Country,
                ShowName = this.FromAddress.ShowName
            },
            To = new AddressDto
            {
                Street = this.ToAddress.Street,
                City = this.ToAddress.City,
                Country = this.ToAddress.Country,
                ShowName = this.ToAddress.ShowName
            }
        };
    }
}

public class Address
    {
        public Guid Id { get; set; }
        public List<TransportOption> TransportOptions { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string? ShowName { get; set; }

        public AddressDto ToDto()
        {
            return new AddressDto
            {
                City = this.City,
                Country = this.Country,
                Street = this.Street,
                ShowName = this.ShowName
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