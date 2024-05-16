using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apigateway.Dtos.Common;
using apigateway.Dtos.Hotels;
using contracts;
using contracts.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apigateway.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelsController : ControllerBase
{
    private readonly ILogger<HotelsController> _logger;
    private readonly IRequestClient<ReservationGetHotelsRequest> _getHotelsClient;
    private readonly IRequestClient<ReservationGetHotelRequest> _getHotelClient;
    private readonly IRequestClient<GetAvailableRoomsRequest> _getAvailableRoomsClient;

    public HotelsController(
        ILogger<HotelsController> logger,
        IRequestClient<ReservationGetHotelsRequest> getHotelsClient,
        IRequestClient<ReservationGetHotelRequest> getHotelClient,
        IRequestClient<GetAvailableRoomsRequest> getAvailableRoomsClient)
    {
        _logger = logger;
        _getHotelsClient = getHotelsClient;
        _getHotelClient = getHotelClient;
        _getAvailableRoomsClient = getAvailableRoomsClient;
    }
    
    [HttpGet(Name = "GetHotels")]
    public async Task<ActionResult<IEnumerable<Hotel>>> Get()
    {
        var response = await _getHotelsClient.GetResponse<ReservationGetHotelsResponse>(new ReservationGetHotelsRequest());
        return Ok(response.Message.Hotels);
    }
    
    [Authorize("RequireAdmin")]
    [HttpPost(Name = "PostHotel")]
    public Hotel Post(HotelCreate hotelCreate)
    {
        // Implement create hotel logic
        return new Hotel();
    }
    
    [HttpGet("{id}", Name = "GetHotel")]
    public async Task<ActionResult<Hotel>> Get(Guid id, DateTime? fromTimeStamp)
    {
        var response = await _getHotelClient.GetResponse<ReservationGetHotelResponse>(new ReservationGetHotelRequest(id));
        return Ok(response.Message.Hotel);
    }
    
    [HttpGet("{id}/RoomsAvailability", Name = "GetHotelRoomsAvailability")]
    public async Task<ActionResult<HotelRoomAvailability>> GetRoomsAvailability(Guid id)
    {
        var response = await _getAvailableRoomsClient.GetResponse<GetAvailableRoomsResponse>(new GetAvailableRoomsRequest(id, DateTime.UtcNow, DateTime.UtcNow.AddDays(1)));
        return Ok(response.Message.Rooms);
    }
    
    [Authorize("RequireAdmin")]
    [HttpPost("{id}/Discount", Name = "PostHotelDiscount")]
    public void PostHotelDiscount(Guid id, HotelDiscount hotelDiscount)
    {
        // Implement post hotel discount logic
    }
}
