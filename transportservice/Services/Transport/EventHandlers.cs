using contracts.Dtos;
using transportservice.Models;

namespace transportservice.Services.Transport;

public class SeatsChangedEvent
{
    public Guid TransportOptionId { get; }
    public int ChangeBy { get; }

    public SeatsChangedEvent(Guid transportOptionId, int changeBy)
    {
        TransportOptionId = transportOptionId;
        ChangeBy = changeBy;
    }
}

public class DiscountAddedEvent
{
    public Guid TransportOptionId { get; }
    public decimal DiscountValue { get; }

    public DiscountAddedEvent(Guid transportOptionId, decimal discountValue)
    {
        TransportOptionId = transportOptionId;
        DiscountValue = discountValue;
    }
}

public class TransportOptionAddedEvent
{
    public TransportOptionDto Dto { get; }

    public TransportOptionAddedEvent(TransportOptionDto dto)
    {
        Dto = dto;
    }
}

// Event Handlers
public class TransportOptionAddedEventHandler
{
    private readonly TransportDbContext _dbContext;

    public TransportOptionAddedEventHandler(TransportDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle(TransportOptionAddedEvent @event)
    {
        var queryTransportOption = new QueryTransportOption
        {
            Id = @event.Dto.Id,
            Start = @event.Dto.Start,
            End = @event.Dto.End,
            PriceAdult = @event.Dto.PriceAdult,
            PriceUnder3 = @event.Dto.PriceUnder3,
            PriceUnder10 = @event.Dto.PriceUnder10,
            PriceUnder18 = @event.Dto.PriceUnder18,
            Type = @event.Dto.Type,
            Seats = @event.Dto.SeatsAvailable,
            FromCity = @event.Dto.FromCity,
            FromCountry = @event.Dto.FromCountry,
            FromStreet = @event.Dto.FromStreet,
            FromShowName = @event.Dto.FromShowName,
            ToCity = @event.Dto.ToCity,
            ToCountry = @event.Dto.ToCountry,
            ToStreet = @event.Dto.ToStreet,
            ToShowName = @event.Dto.ToShowName,
            Discount = null
        };

        _dbContext.QueryTransportOptions.Add(queryTransportOption);
        _dbContext.SaveChanges();
    }
}

public class SeatsChangedEventHandler
{
    private readonly TransportDbContext _dbContext;

    public SeatsChangedEventHandler(TransportDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle(SeatsChangedEvent @event)
    {
        var queryTransportOption = _dbContext.QueryTransportOptions
            .FirstOrDefault(to => to.Id == @event.TransportOptionId);

        if (queryTransportOption != null)
        {
            queryTransportOption.Seats += @event.ChangeBy;
            _dbContext.SaveChanges();
        }
    }
}

public class DiscountAddedEventHandler
{
    private readonly TransportDbContext _dbContext;

    public DiscountAddedEventHandler(TransportDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle(DiscountAddedEvent @event)
    {
        var queryTransportOption = _dbContext.QueryTransportOptions
            .FirstOrDefault(to => to.Id == @event.TransportOptionId);

        if (queryTransportOption != null)
        {
            queryTransportOption.Discount = @event.DiscountValue;
            _dbContext.SaveChanges();
        }
    }
}
