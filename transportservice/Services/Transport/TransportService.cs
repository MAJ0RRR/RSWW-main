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
        var transport = new TransportOption
        {
            Id = Guid.NewGuid(),
            FromCountry = request.TransportOption.From.Country,
            FromCity = request.TransportOption.From.City,
            FromStreet = request.TransportOption.From.Street,
            FromShowName = request.TransportOption.From.ShowName,
            ToCountry = request.TransportOption.To.Country,
            ToCity = request.TransportOption.To.City,
            ToStreet = request.TransportOption.To.Street,
            ToShowName = request.TransportOption.To.ShowName,
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

    public async Task<GetTransportOptionsResponse> GetTransportOptions(GetTransportOptionsRequest request)
    {
        var transportQuery = _dbContext.TransportOptions
            .Include(to => to.Discounts)
            .Include(to => to.SeatsChanges)
            .AsQueryable();

        var transports = await transportQuery.ToListAsync();

        var transportsDto = transports.Select(transport => transport.ToDto()).ToList();

        return new GetTransportOptionsResponse(transportsDto);
    }

    public async Task<GetTransportOptionResponse> GetTransportOption(GetTransportOptionRequest request)
    {
        var transportQuery = await _dbContext.TransportOptions
            .Include(to => to.Discounts)
            .Include(to => to.SeatsChanges)
            .FirstOrDefaultAsync(to => to.Id == request.Id);

        if (transportQuery == null)
        {
            return null;
        }
        
        var transportsDto = transportQuery.ToDto();

        return new GetTransportOptionResponse(transportsDto);
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
