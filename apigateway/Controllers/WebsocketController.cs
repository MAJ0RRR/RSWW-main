// WebSocketController.cs
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Channels;
using contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace apigateway.Controllers;


public class Subscription
{
    public Guid HotelId { get; set; }
    public Guid? ToTransportOptionId { get; set; }
    public Guid? FromTransportOptionId { get; set; }
}

[ApiExplorerSettings(IgnoreApi = true)]
public class WebSocketController : ControllerBase
{
    private readonly Channel<TourReservedEvent> _channel;
    private readonly ILogger<WebSocketController> _logger;

    public WebSocketController(Channel<TourReservedEvent> channel, ILogger<WebSocketController> logger)
    {
        _channel = channel;
        _logger = logger;
    }

    [Route("/ws")]
    public async Task GetWs(CancellationToken cancellationToken)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var hotelId = HttpContext.Request.Query.ContainsKey("hotelId") 
                ? Guid.Parse(HttpContext.Request.Query["hotelId"]) 
                : (Guid?)null;
            var toTransportOptionId = HttpContext.Request.Query.ContainsKey("toTransportOptionId") 
                ? Guid.Parse(HttpContext.Request.Query["toTransportOptionId"]) 
                : (Guid?)null;
            var fromTransportOptionId = HttpContext.Request.Query.ContainsKey("fromTransportOptionId") 
                ? Guid.Parse(HttpContext.Request.Query["fromTransportOptionId"]) 
                : (Guid?)null;
            
            var subscription = !hotelId.HasValue ? null : new Subscription
            {
                HotelId = hotelId.Value,
                ToTransportOptionId = toTransportOptionId,
                FromTransportOptionId = fromTransportOptionId
            };

            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await HandleWebSocketConnection(webSocket, subscription, cancellationToken);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandleWebSocketConnection(WebSocket webSocket, Subscription? subscription, CancellationToken cancellationToken)
    {
        try
        {
            await BroadcastService.AddClientAsync(webSocket, subscription, cancellationToken);

            while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("WebSocket connection was cancelled.");
        }
        finally
        {
            BroadcastService.RemoveClient(webSocket);

            if (webSocket.State == WebSocketState.Open || webSocket.State == WebSocketState.CloseReceived)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
            }
        }
    }


    public class BroadcastService : BackgroundService
    {
        private readonly Channel<TourReservedEvent> _channel;
        private readonly ILogger<BroadcastService> _logger;
        private static readonly ConcurrentDictionary<WebSocket, Subscription?> _subscriptions = new ConcurrentDictionary<WebSocket, Subscription?>();

        public BroadcastService(Channel<TourReservedEvent> channel, ILogger<BroadcastService> logger)
        {
            _channel = channel;
            _logger = logger;
        }

        public static Task AddClientAsync(WebSocket webSocket, Subscription? subscription, CancellationToken cancellationToken)
        {
            _subscriptions.TryAdd(webSocket, subscription);
            return Task.CompletedTask;
        }

        public static void RemoveClient(WebSocket webSocket)
        {
            _subscriptions.TryRemove(webSocket, out _);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var reader = _channel.Reader;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var reservedEvent = await reader.ReadAsync(stoppingToken);
                    await BroadcastNotification(reservedEvent, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Broadcasting operation was cancelled.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while broadcasting.");
                }
            }
        }

        private async Task BroadcastNotification(TourReservedEvent reservedEvent, CancellationToken cancellationToken)
        {
            var message = JsonSerializer.Serialize(reservedEvent);
            var buffer = Encoding.UTF8.GetBytes(message);
            var segment = new ArraySegment<byte>(buffer);

            foreach (var (socket, subscription) in _subscriptions)
            {
                if (socket.State == WebSocketState.Open && MatchesSubscription(reservedEvent, subscription))
                {
                    await socket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
                    _logger.LogInformation("Sent: " + message);
                }
            }
        }

        private bool MatchesSubscription(TourReservedEvent reservedEvent, Subscription? subscription)
        {
            if (subscription == null)
                return true;

            return (reservedEvent.HotelId == subscription.HotelId) &&
                   (!subscription.ToTransportOptionId.HasValue || reservedEvent.ToTransportOptionId == subscription.ToTransportOptionId) &&
                   (!subscription.FromTransportOptionId.HasValue || reservedEvent.FromTransportOptionId == subscription.FromTransportOptionId);
        }
    }
}
    
