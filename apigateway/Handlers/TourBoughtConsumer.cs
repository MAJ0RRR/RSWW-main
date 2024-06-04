using contracts;
using MassTransit;

namespace apigateway.Handlers;

public class TourBoughtConsumer : IConsumer<TourBoughtEvent>
{
    private readonly ILogger<TourBoughtConsumer> _logger;

    public TourBoughtConsumer(ILogger<TourBoughtConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TourBoughtEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("Tour Bought: HotelId={HotelId}, ReservationId={ReservationId} ToTransportOptionId={ToTransportOptionId}, FromTransportOptionId={FromTransportOptionId}",
            message.HotelId, message.ReservatonId, message.ToTransportOptionId, message.FromTransportOptionId);
            
        return Task.CompletedTask;
    }
}