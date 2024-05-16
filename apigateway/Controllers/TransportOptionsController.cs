using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apigateway.Dtos.TransportOptions;
using contracts;
using contracts.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apigateway.Controllers;

[ApiController]
[Route("[controller]")]
public class TransportOptionsController : ControllerBase
{
    private readonly ILogger<TransportOptionsController> _logger;
    private readonly IRequestClient<ReservationGetTransportOptionsRequest> _getTransportOptionsClient;
    private readonly IRequestClient<ReservationGetTransportOptionRequest> _getTransportOptionClient;

    public TransportOptionsController(
        ILogger<TransportOptionsController> logger,
        IRequestClient<ReservationGetTransportOptionsRequest> getTransportOptionsClient,
        IRequestClient<ReservationGetTransportOptionRequest> getTransportOptionClient)
    {
        _logger = logger;
        _getTransportOptionsClient = getTransportOptionsClient;
        _getTransportOptionClient = getTransportOptionClient;
    }
    
    [HttpGet(Name = "GetTransportOptions")]
    public async Task<ActionResult<IEnumerable<TransportOption>>> Get()
    {
        var response = await _getTransportOptionsClient.GetResponse<ReservationGetTransportOptionsResponse>(new ReservationGetTransportOptionsRequest());
        return Ok(response.Message.TransportOptions);
    }
    
    [Authorize("RequireAdmin")]
    [HttpPost(Name = "PostTransportOption")]
    public TransportOption Post(TransportOptionCreate transportOptionCreate)
    {
        // Implement create transport option logic
        return new TransportOption();
    }
    
    [HttpGet("{id}", Name = "GetTransportOption")]
    public async Task<ActionResult<TransportOption>> Get(Guid id, DateTime? fromTimeStamp)
    {
        var response = await _getTransportOptionClient.GetResponse<ReservationGetTransportOptionResponse>(new ReservationGetTransportOptionRequest(id));
        return Ok(response.Message.TransportOption);
    }
    
    [Authorize("RequireAdmin")]
    [HttpPost("{id}/Discount", Name = "PostTransportOptionDiscount")]
    public void PostTransportOptionDiscount(Guid id, TransportOptionDiscount transportOptionDiscount)
    {
        // Implement post transport option discount logic
    }
}
