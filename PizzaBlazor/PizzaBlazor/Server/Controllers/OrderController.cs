using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
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
        var allOrdersWithStatus = _orderService.GetAllOrdersWithStatus();
        var DtoOrderStatus = allOrdersWithStatus.Select(ows =>
        {

            return new OrderDTO
            {
                OrderId = ows.OrderId,
                CreatedTime = ows.CreatedTime,
                DeliveryAddress = new AddressDTO(
                    ows.DeliveryAddress.Id,
                    ows.DeliveryAddress.Name,
                    ows.DeliveryAddress.Line1,
                    ows.DeliveryAddress.Line2,
                    ows.DeliveryAddress.City,
                    ows.DeliveryAddress.Region,
                    ows.DeliveryAddress.PostalCode
                ),
                Pizzas = ows.Pizzas.Select(pz =>
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
                }).ToList(),
                StatusText = ows.GetStatus()
            };
        }).ToList();

        return DtoOrderStatus;
    }

    [HttpGet("status/{orderId}")]
    public OrderDTO GetOrderWithStatus(Guid orderId)
    {
        var orderStatus = _orderService.GetOrderWithStatus(orderId);
        var DtoOrderStatus = new OrderDTO
        {
            CreatedTime = orderStatus.CreatedTime,
            DeliveryAddress = new AddressDTO
            {
                Name = orderStatus.DeliveryAddress.Name,
                Id = orderStatus.DeliveryAddress.Id,
                City = orderStatus.DeliveryAddress.City,
                Region = orderStatus.DeliveryAddress.Region,
                Line1 = orderStatus.DeliveryAddress.Line1,
                Line2 = orderStatus.DeliveryAddress.Line2,
                PostalCode = orderStatus.DeliveryAddress.PostalCode,
            },
            OrderId = orderId,
            Pizzas = orderStatus.Pizzas.Select(pzz =>
            {
                return new PizzaDTO(pzz.Id,
                    new PizzaSpecialDTO(pzz.Special.Id, pzz.Special.Name, pzz.Special.BasePrice,
                    pzz.Special.Description,
                    pzz.Special.ImageUrl,
                    pzz.Special.FixedSize),
                    pzz.Id, pzz.Size,
                    pzz.Toppings.Select(tpp =>
                    {
                        return new ToppingDTO(tpp.Id, tpp.Name, tpp.Price);
                    }).ToList());
            }).ToList(),
            StatusText = orderStatus.GetStatus()
        };

        return DtoOrderStatus;
    }
}
