using MassTransit;
using Microsoft.EntityFrameworkCore;
using hotelservice.Handlers;
using hotelservice.Models;
using hotelservice.Services.Hotel;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    // Add MassTransit
    services.AddMassTransit(busConfigurator =>
    {
        busConfigurator.SetKebabCaseEndpointNameFormatter();
            
        // Add consumers
        busConfigurator.AddConsumer<AddHotelRequestConsumer>();
        busConfigurator.AddConsumer<HotelCheckAvailabilityRequestConsumer>();
        busConfigurator.AddConsumer<GetHotelsRequestConsumer>();
        busConfigurator.AddConsumer<GetHotelRequestConsumer>();
        busConfigurator.AddConsumer<HotelBookRoomsRequestConsumer>();
        busConfigurator.AddConsumer<HotelGetAvailableRoomsRequestConsumer>();
        busConfigurator.AddConsumer<HotelAddDiscountRequestConsumer>();
        busConfigurator.AddConsumer<HotelCancelBookRoomsRequestConsumer>();
        
        busConfigurator.UsingRabbitMq((context,cfg) =>
        {
            cfg.Host("127.0.0.1", "/", h => {
                h.Username("user_rabbitmq");
                h.Password("password_rabbitmq");
            });
            cfg.ConfigureEndpoints(context);
        });
    });
    
    services.AddDbContext<HotelDbContext>(options => options.UseNpgsql("Host=127.0.0.1:5432;Database=hotelservice_db;Username=user_hotelservice_db;Password=password_hotelservice_db"));
    services.AddScoped<HotelService>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    context.Database.Migrate();
}

await app.RunAsync();
