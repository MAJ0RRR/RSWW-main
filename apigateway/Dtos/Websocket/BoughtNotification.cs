using System.ComponentModel.DataAnnotations;

namespace apigateway.Dtos.Websocket;

public class BoughtNotification
{
    [Required] public string User { get; set; }
}