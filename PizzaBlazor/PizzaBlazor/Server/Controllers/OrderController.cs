using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Order;
using PizzaBlazor.Shared.DtoModels.Pizza;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
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
    public List<OrderWithStatusDTO> GetOrdersWithStatus()
    {
        var allOrdersWithStatus = _orderService.GetAllOrdersWithStatus();
        var DtoOrderStatus = allOrdersWithStatus.Select(ows =>
        {
            return new OrderWithStatusDTO
            {
                Order = new OrderDTO
                {
                    OrderId = ows.Order.OrderId,
                    CreatedTime = ows.Order.CreatedTime,
                    DeliveryAddress = new AddressDTO(
                        ows.Order.DeliveryAddress.Id,
                        ows.Order.DeliveryAddress.Name,
                        ows.Order.DeliveryAddress.Line1,
                        ows.Order.DeliveryAddress.Line2,
                        ows.Order.DeliveryAddress.City,
                        ows.Order.DeliveryAddress.Region,
                        ows.Order.DeliveryAddress.PostalCode
                    ),
                    Pizzas = ows.Order.Pizzas.Select(pz =>
                    {
                        return new PizzaDTO
                        {
                            Id = pz.Id,
                            Size = pz.Size,
                            Special = new PizzaSpecialDTO(
                                pz.Special.Id,
                                pz.Special.Name,
                                pz.Special.BasePrice,
                                pz.Special.Description,
                                pz.Special.ImageUrl,
                                pz.Special.FixedSize
                            ),
                            SpecialId = pz.SpecialId,
                            Toppings = pz.Toppings.Select(tpp =>
                            {
                                return new ToppingDTO
                                {
                                    Name = tpp.Name,
                                    Id = tpp.Id,
                                    Price = tpp.Price
                                };
                            }).ToList()
                        };
                    }).ToList()
                },
                StatusText = ows.StatusText
            };
        }).ToList();

        return DtoOrderStatus;

    }

    [HttpGet("status/{orderId}")]
    public IActionResult GetOrderWithStatus(Guid orderId)
    {
        var orderStatus = _orderService.GetOrderWithStatus(orderId);
        return Ok(orderStatus);
    }
}
