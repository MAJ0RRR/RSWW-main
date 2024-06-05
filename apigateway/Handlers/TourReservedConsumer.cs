using contracts;
using MassTransit;

namespace apigateway.Handlers;

public class TourReservedConsumer : IConsumer<TourReservedEvent>
{
    private readonly ILogger<TourReservedConsumer> _logger;

    public TourReservedConsumer(ILogger<TourReservedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TourReservedEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("Tour Reserved: HotelId={HotelId}, ReservationId={ReservationId} ToTransportOptionId={ToTransportOptionId}, FromTransportOptionId={FromTransportOptionId}",
            message.HotelId, message.ReservatonId, message.ToTransportOptionId, message.FromTransportOptionId);
            
        return Task.CompletedTask;
    }
}