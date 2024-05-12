using contracts;
using MassTransit;

namespace userservice.Services;

public class LoginRequestConsumer : IConsumer<LoginRequest>
{
    private readonly ILogger<LoginRequestConsumer> _logger;
    public LoginRequestConsumer(ILogger<LoginRequestConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<LoginRequest> context)
    {
        _logger.LogInformation("{Consumer}: {Message}", nameof(LoginRequestConsumer), context.Message);
        
        var response = new LoginResponse(Token: null);
        if (context.Message.Username == "user" & context.Message.Password == "pass")
        {
            response = new LoginResponse(Token: "123445");
        }
        await context.RespondAsync(response);
    }
}