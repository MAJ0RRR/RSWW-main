using MassTransit;
using userservice.Services;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    // Add MassTransit
    services.AddMassTransit(busConfigurator =>
    {
        busConfigurator.SetKebabCaseEndpointNameFormatter();
            
        // Add consumers
        busConfigurator.AddConsumer<LoginRequestConsumer>();
        
        busConfigurator.UsingRabbitMq((context,cfg) =>
        {
            cfg.Host("localhost", "/", h => {
                h.Username("guest");
                h.Password("guest");
            });
            cfg.ConfigureEndpoints(context);
        });
    });
});

var app = builder.Build();

await app.RunAsync();
