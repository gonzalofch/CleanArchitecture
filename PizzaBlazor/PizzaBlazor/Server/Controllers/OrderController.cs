using Application.UseCases;
using Application.UseCases.Create;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Server.Mappers;
using PizzaBlazor.Shared.DtoModels.Order;

namespace PizzaBlazor.Server.Controllers;

[Route("orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult Post(OrderCreateInfo order)
    {
        var orderId = _orderService.AddOrder(order);
        return Ok(orderId);
    }

    [HttpGet("status")]
    public List<OrderDTO> GetOrdersWithStatus()
    {
        List<Order> allOrdersWithStatus = _orderService.GetAllOrdersWithStatus();
        return allOrdersWithStatus.MapToDTOList();
    }

    [HttpGet("status/{orderId}")]
    public OrderDTO GetOrderWithStatus(Guid orderId)
    {
        Order orderStatus = _orderService.GetOrderWithStatus(orderId);
        return orderStatus.MapToDTO();
    }
}
