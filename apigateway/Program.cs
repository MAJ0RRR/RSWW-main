using apigateway.Authentication;
using apigateway.Handlers;
using apigateway.Swagger;
using MassTransit;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeCheckOperationFilter>();
    options.AddSecurityDefinition("Token", new OpenApiSecurityScheme
    {
        Description = "Token authentication.",
        Name = "Authorization", // Nagłówek, w którym znajduje się token
        In = ParameterLocation.Header, // Gdzie znajduje się token: w nagłówku
        Type = SecuritySchemeType.ApiKey, // Typ uwierzytelniania (ApiKey w przypadku nagłówka Authorization)
        Scheme = "ApiKeyAuth" // Nazwa schematu uwierzytelniania
    });
});

// Add MassTransit
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    
    busConfigurator.AddConsumer<TourReservedConsumer>();
    
    busConfigurator.UsingRabbitMq((context,cfg) =>
    {
        var rabbitMQHost = configuration.GetConnectionString("RabbitMQHost");
        var rabbitMQUser = configuration.GetConnectionString("RabbitMQUser");
        var rabbitMQPassword = configuration.GetConnectionString("RabbitMQPassword");
        
        cfg.Host(rabbitMQHost, "/", h => {
            h.Username(rabbitMQUser);
            h.Password(rabbitMQPassword);
        });
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddAuthentication("Token")
    .AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Token", null);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy =>
        policy.RequireClaim("IsAdmin", "True"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

// REENABLE LATER
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
