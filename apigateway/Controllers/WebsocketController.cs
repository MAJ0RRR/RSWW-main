using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using apigateway.Dtos.Websocket;
using Microsoft.AspNetCore.Mvc;

namespace apigateway.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class WebSocketController : ControllerBase
{
    [Route("/ws")]
    public async Task GetWs(CancellationToken cancellationToken)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await HandleWebSocketConnection(webSocket, cancellationToken);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    
    private async Task HandleWebSocketConnection(WebSocket webSocket, CancellationToken cancellationToken)
    {
        try
        {
            while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var notification = new BoughtNotification { User = "user0" };
                await SendNotification(webSocket, notification, cancellationToken);
                await Task.Delay(3000, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            // Handle the cancellation
            Console.WriteLine("Operation was cancelled.");
        }
        finally
        {
            if (webSocket.State == WebSocketState.Open || webSocket.State == WebSocketState.CloseReceived)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
            }
        }
    }

    private async Task SendNotification(WebSocket webSocket, BoughtNotification notification, CancellationToken cancellationToken)
    {
        var message = JsonSerializer.Serialize(notification);
        var buffer = Encoding.UTF8.GetBytes(message);
        var segment = new ArraySegment<byte>(buffer);

        await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
        Console.WriteLine("Sent: " + message);
    }
}
