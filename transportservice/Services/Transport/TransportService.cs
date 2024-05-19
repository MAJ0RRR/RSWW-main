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
            Start = request.TransportOption.Start,
            End = request.TransportOption.End,
            InitialSeats = request.TransportOption.SeatsAvailable,
            PriceAdult = request.TransportOption.PriceAdult,

    }

    public TransportOptionSearchResponse SearchTransportOptions(TransportOptionSearchRequest request)
    {
        return new TransportOptionSearchResponse(new List<TransportOptionDto>
        {
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                FromCity = "Warsaw",
                FromCountry = "Poland",
                FromStreet = "Sample Street",
                FromShowName = "Sample Show Name",
                ToCity = "Berlin",
                ToCountry = "Germany",
                ToStreet = "Destination Street",
                ToShowName = "Destination Show Name",
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Plane",
            },
            
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                FromCity = "Berlin",
                FromCountry = "Germany",
                FromStreet = "Sample Street",
                FromShowName = "Sample Show Name",
                ToCity = "Warsaw",
                ToCountry = "Poland",
                ToStreet = "Destination Street",
                ToShowName = "Destination Show Name",
                Start = DateTime.Now.AddHours(10),
                End = DateTime.Now.AddHours(14),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Plane",
            },
        });
    }

    public async Task<GetTransportOptionsResponse> GetTransportOptions(GetTransportOptionsRequest request)
    {

    }

    public async Task<GetTransportOptionResponse> GetTransportOption(GetTransportOptionRequest request)
    {
        var transportQuery = await _dbContext.TransportOptions
            .Include(to => to.Discounts)
            .Include(to => to.SeatsChanges)
            .FirstOrDefaultAsync(to => to.Id == request.Id);

        if (transportQuery == null)
        {

    }

    public TransportOptionAddSeatsResponse AddSeats(TransportOptionAddSeatsRequest request)
    {
        return new TransportOptionAddSeatsResponse();
    }

    public async Task<TransportOptionAddDiscountResponse> AddDiscount(TransportOptionAddDiscountRequest request)
    {
        var transportQuery = await _dbContext.TransportOptions
            .Include(to => to.Discounts)
            .Include(to => to.SeatsChanges)
            .FirstOrDefaultAsync(to => to.Id == request.Id);

        if(transportQuery == null)
        {
            return null;
        }

        var newDiscount = new Discount
        {
            Id = Guid.NewGuid(),
            TransportOptionId = request.Id,
            Value = request.Discount.Value,
            Start = request.Discount.Start,
            End = request.Discount.End
        };

        await _dbContext.Discounts.AddAsync(newDiscount);
        await _dbContext.SaveChangesAsync();
        
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
            FromCity = "Berlin",
            FromCountry = "Germany",
            FromStreet = "Sample Street",
            FromShowName = "Sample Show Name",
            ToCity = "Warsaw",
            ToCountry = "Poland",
            ToStreet = "Destination Street",
            ToShowName = "Destination Show Name",
            Start = request.When,
            End = request.When.AddHours(4),
            SeatsAvailable = 50,
            PriceAdult = 100,
            PriceUnder3 = 50,
            PriceUnder10 = 70,
            PriceUnder18 = 80,
            Type = "Plane",
        });
    }

    public GetPopularDestinationsResponse GetPopularDestinations(GetPopularDestinationsRequest request)
    {
        return new GetPopularDestinationsResponse(new List<TransportOptionDto>
        {
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                FromCity = "Berlin",
                FromCountry = "Germany",
                FromStreet = "Sample Street",
                FromShowName = "Sample Show Name",
                ToCity = "Warsaw",
                ToCountry = "Poland",
                ToStreet = "Destination Street",
                ToShowName = "Destination Show Name",
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Plane",
            },
            new TransportOptionDto
            {
                Id = Guid.NewGuid(),
                FromCity = "Berlin",
                FromCountry = "Germany",
                FromStreet = "Sample Street",
                FromShowName = "Sample Show Name",
                ToCity = "Warsaw",
                ToCountry = "Poland",
                ToStreet = "Destination Street",
                ToShowName = "Destination Show Name",
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(5),
                SeatsAvailable = 50,
                PriceAdult = 100,
                PriceUnder3 = 50,
                PriceUnder10 = 70,
                PriceUnder18 = 80,
                Type = "Plane",
            }
        });
    }


}
