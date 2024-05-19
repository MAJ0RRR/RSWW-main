using System.Security.Cryptography;
using contracts;
using contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using transportservice.Models;

namespace transportservice.Services.Transport;

public class TransportService
{
    private readonly TransportDbContext _dbContext;

    public TransportService(TransportDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<AddTransportOptionResponse> AddTransportOption(AddTransportOptionRequest request)
    {
        var From = new Address
        {
            Id = new Guid(),
            Country = request.TransportOption.From.Country,
            City = request.TransportOption.From.City,
            Street = request.TransportOption.From.Street,
            ShowName = request.TransportOption.From.ShowName
        };
        
        var To = new Address
        {
            Id = new Guid(),
            Country = request.TransportOption.To.Country,
            City = request.TransportOption.To.City,
            Street = request.TransportOption.To.Street,
            ShowName = request.TransportOption.To.ShowName
        };
        
        var transport = new TransportOption
        {
            Id = Guid.NewGuid(),
            FromAddressId = From.Id,
            ToAddressId = To.Id,
            Start = request.TransportOption.Start,
            End = request.TransportOption.End,
            InitialSeats = request.TransportOption.SeatsAvailable,
            PriceAdult = request.TransportOption.PriceAdult,
            Type = request.TransportOption.Type,
        };
        
        _dbContext.TransportOptions.Add(transport);
        await _dbContext.SaveChangesAsync();
        
        return new AddTransportOptionResponse(transport.ToDto());
    }

    public TransportOptionSearchResponse SearchTransportOptions(TransportOptionSearchRequest request)
    {
        return new TransportOptionSearchResponse(new List<TransportOptionDto>
        {
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
                To = new AddressDto { City = "Destination City", Country = "Destination Country", Street = "Destination Street", ShowName = "Destination Show Name" },
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Airplane",
                Discounts = new List<DiscountDto>()
            }
        });
    }

    public GetTransportOptionsResponse GetTransportOptions(GetTransportOptionsRequest request)
    {
        return new GetTransportOptionsResponse(new List<TransportOptionDto>
        {
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
                To = new AddressDto { City = "Berlin", Country = "Germany", Street = "Destination Street", ShowName = "Destination Show Name" },
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Airplane",
                Discounts = new List<DiscountDto>()
            },
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
                To = new AddressDto { City = "Warsaw", Country = "Poland", Street = "Destination Street", ShowName = "Destination Show Name" },
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Airplane",
                Discounts = new List<DiscountDto>()
            }
        });
    }

    public GetTransportOptionResponse GetTransportOption(GetTransportOptionRequest request)
    {
        return new GetTransportOptionResponse(new TransportOptionDto
        {
            Id = request.Id,
            From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
            To = new AddressDto { City = "Destination City", Country = "Destination Country", Street = "Destination Street", ShowName = "Destination Show Name" },
            Start = DateTime.Now.AddHours(1),
            End = DateTime.Now.AddHours(5),
            SeatsAvailable = 50,
            PriceAdult = 100,
            PriceUnder3 = 50,
            PriceUnder10 = 70,
            PriceUnder18 = 80,
            Type = "Airplane",
            Discounts = new List<DiscountDto>()
        });
    }

    public TransportOptionAddSeatsResponse AddSeats(TransportOptionAddSeatsRequest request)
    {
        return new TransportOptionAddSeatsResponse();
    }

    public TransportOptionAddDiscountResponse AddDiscount(TransportOptionAddDiscountRequest request)
    {
        return new TransportOptionAddDiscountResponse();
    }

    public TransportOptionSubtractSeatsResponse SubtractSeats(TransportOptionSubtractSeatsRequest request)
    {
        return new TransportOptionSubtractSeatsResponse(true);
    }

    public GetTransportOptionWhenResponse GetTransportOptionWhen(GetTransportOptionWhenRequest request)
    {
        return new GetTransportOptionWhenResponse(new TransportOptionDto
        {
            Id = Guid.NewGuid(),
            From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
            To = new AddressDto { City = "Destination City", Country = "Destination Country", Street = "Destination Street", ShowName = "Destination Show Name" },
            Start = request.When,
            End = request.When.AddHours(4),
            SeatsAvailable = 50,
            PriceAdult = 100,
            PriceUnder3 = 50,
            PriceUnder10 = 70,
            PriceUnder18 = 80,
            Type = "Airplane",
            Discounts = new List<DiscountDto>()
        });
    }

    public GetPopularDestinationsResponse GetPopularDestinations(GetPopularDestinationsRequest request)
    {
        return new GetPopularDestinationsResponse(new List<TransportOptionDto>
        {
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
                To = new AddressDto { City = "Berlin", Country = "Germany", Street = "Destination Street", ShowName = "Destination Show Name" },
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Airplane",
                Discounts = new List<DiscountDto>()
            },
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                From = new AddressDto { City = "Sample City", Country = "Sample Country", Street = "Sample Street", ShowName = "Sample Show Name" },
                To = new AddressDto { City = "Warsaw", Country = "Poland", Street = "Destination Street", ShowName = "Destination Show Name" },
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Airplane",
                Discounts = new List<DiscountDto>()
            }
        });
    }


}
