using CleanArchitecture.OrderManagement.Application.DTOs.Orders;
using CleanArchitecture.OrderManagement.Application.Services.Orders;
using Microsoft.AspNetCore.Mvc;


namespace Pedidos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
    {
        var result = await _orderService.CriarOrderAsync(request);
        return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var pedido = await _orderService.GetOrderIdAsync(id);
        return pedido is not null ? Ok(pedido) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> ListarPorStatus([FromQuery] string status)
    {
        var pedidos = await _orderService.ListOrderStatusAsync(status);
        return Ok(pedidos);
    }
}

