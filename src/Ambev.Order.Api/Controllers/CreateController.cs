using CleanArchitecture.OrderManagement.Application.DTOs.Client.Request;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Application.Services.Orders;
using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;
using Microsoft.AspNetCore.Mvc;


namespace Pedidos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreateController : ControllerBase
{
    private readonly IClientService _clientService;

    public CreateController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
    {
        var result = await _clientService.AddAsync(request);
        return CreatedAtAction(nameof(GetClientId), new { clientId = result.Clientid }, result);
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientId(Guid clientId)
    {
        var pedido = await _clientService.GetClientByIdAsync(clientId);
        return pedido is not null ? Ok(pedido) : NotFound();
    }


}

