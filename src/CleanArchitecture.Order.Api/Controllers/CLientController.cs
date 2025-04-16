using CleanArchitecture.OrderManagement.Application.DTOs.Client.Request;
using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.OrderManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CLientController : ControllerBase
{
    private readonly IClientService _clientService;

    public CLientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
    {
          await _clientService.AddAsync(request);
        return NoContent();
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientId(Guid clientId)
    {
        var pedido = await _clientService.GetClientByIdAsync(clientId);
        return pedido is not null ? Ok(pedido) : NotFound();
    }
}
public class Client
{
    public Guid ClientId { get; private set; }
    public string Name { get; private set; }

    // Fix: Add a constructor to initialize the private properties
    public Client(Guid clientId, string name)
    {
        ClientId = clientId;
        Name = name;
    }
}

