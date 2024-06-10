using Application.UseCases;
using Application.UseCases.Create;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Server.Mappers;
using PizzaBlazor.Shared.DtoModels;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Order;
using PizzaBlazor.Shared.DtoModels.Pizza;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Shared.DtoModels.Topping;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
