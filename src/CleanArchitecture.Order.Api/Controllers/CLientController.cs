using CleanArchitecture.OrderManagement.Application.DTOs.Client.Request;
using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.OrderManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(
    IClientService clientService, 
    IValidator<CreateClientRequest> validator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
        await clientService.AddAsync(request);
        return NoContent();
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientId(Guid clientId)
    {
        var pedido = await clientService.GetClientByIdAsync(clientId);
        return pedido is not null ? Ok(pedido) : NotFound();
    }
}


