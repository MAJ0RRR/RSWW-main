using apigateway.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace apigateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost("Login", Name = "PostAuthLogin")]
    public TokenInfo PostLogin(LoginInfo loginInfo)
    {
        return new TokenInfo()
        {
            Token = "1234"
        };
    }
}