﻿
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.Services.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.OrderManagement.Api.Controllers;

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
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var result = await _orderService.CreateOrderAsync(request);
        return CreatedAtAction(nameof(ObterPorId), new { id = result.OrderId }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid ClientId)
    {
        var pedido = await _orderService.GetOrderByIdAsync(ClientId);
        return pedido is not null ? Ok(pedido) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> ListarPorStatus([FromQuery] Status status)
    {
        var pedidos = await _orderService.ListOrderByStatusAsync(status);
        return Ok(pedidos);
    }
}

