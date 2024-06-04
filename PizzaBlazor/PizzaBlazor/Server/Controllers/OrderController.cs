using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBlazor.Server.Controllers;

[Route("orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _unitOfWork.Orders.GetAll()
    .Select(_ => new OrderDTO(
        _.OrderId,
        //_.UserId,
        _.CreatedTime,
        new AddressDTO(
            _.DeliveryAddress.Id,
            _.DeliveryAddress.Name,
            _.DeliveryAddress.Line1,
            _.DeliveryAddress.Line2,
            _.DeliveryAddress.City,
            _.DeliveryAddress.Region,
            _.DeliveryAddress.PostalCode
        ),
        _.Pizzas.Select(p => new PizzaDTO(
            p.Id,
            p.OrderId,
            new PizzaSpecialDTO(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaToppingDTO(
                new ToppingDTO(
                    t.Topping.Id,
                    t.Topping.Name,
                    t.Topping.Price
                ),
                t.ToppingId,
                t.PizzaId
            )).ToList()
        )).ToList()
    )).ToList();

        return Ok(orders);
    }

    [HttpGet("details/{guid}")]
    public OrderDTO GetOrder(Guid guid)
    {
        var order = _unitOfWork.Orders.GetByGuid(guid);
        return new OrderDTO(
        order.OrderId,
        //order.UserId,
        order.CreatedTime,
        new AddressDTO(
            order.DeliveryAddress.Id,
            order.DeliveryAddress.Name,
            order.DeliveryAddress.Line1,
            order.DeliveryAddress.Line2,
            order.DeliveryAddress.City,
            order.DeliveryAddress.Region,
            order.DeliveryAddress.PostalCode
        ),
        order.Pizzas.Select(p => new PizzaDTO(
            p.Id,
            p.OrderId,
            new PizzaSpecialDTO(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaToppingDTO(
                new ToppingDTO(
                    t.Topping.Id,
                    t.Topping.Name,
                    t.Topping.Price
                ),
                t.ToppingId,
                t.PizzaId
            )).ToList()
        )).ToList()
    );
    }
    [HttpGet("status")]
    public IActionResult GetOrdersWithStatus()
    {
        var orders = _unitOfWork.Orders.GetAll()
            .Select(o => new OrderDTO(
        o.OrderId,
        //o.UserId,
        o.CreatedTime,
        new AddressDTO(
            o.DeliveryAddress.Id,
            o.DeliveryAddress.Name,
            o.DeliveryAddress.Line1,
            o.DeliveryAddress.Line2,
            o.DeliveryAddress.City,
            o.DeliveryAddress.Region,
            o.DeliveryAddress.PostalCode
        ),
        o.Pizzas.Select(p => new PizzaDTO(
            p.Id,
            p.OrderId,
            new PizzaSpecialDTO(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaToppingDTO(
                new ToppingDTO(
                    t.Topping.Id,
                    t.Topping.Name,
                    t.Topping.Price
                ),
                t.ToppingId,
                t.PizzaId
            )).ToList()
        )).ToList()));

        var ordersWithStatus = orders.Select(orderDto => OrderWithStatusDTO.FromOrder(orderDto)).ToList();

        return Ok(ordersWithStatus);
    }

    [HttpGet("status/{orderId}")]
    public IActionResult GetOrderWithStatus(Guid orderId)
    {
        var order = _unitOfWork.Orders
            .Find(o => o.OrderId == orderId).First();
        var orderDto = new OrderDTO(
        order.OrderId,
        //order.UserId,
        order.CreatedTime,
        new AddressDTO(
            order.DeliveryAddress.Id,
            order.DeliveryAddress.Name,
            order.DeliveryAddress.Line1,
            order.DeliveryAddress.Line2,
            order.DeliveryAddress.City,
            order.DeliveryAddress.Region,
            order.DeliveryAddress.PostalCode
        ),
        order.Pizzas.Select(p => new PizzaDTO(
            p.Id,
            p.OrderId,
            new PizzaSpecialDTO(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaToppingDTO(
                new ToppingDTO(
                    t.Topping.Id,
                    t.Topping.Name,
                    t.Topping.Price
                ),
                t.ToppingId,
                t.PizzaId
            )).ToList()
        )).ToList());

        if (order == null)
        {
            return NotFound();
        }

        return Ok(OrderWithStatusDTO.FromOrder(orderDto));
    }

    [HttpPost]
    public IActionResult Post(OrderDTO order)
    {
        Order orderEntity = new Order(
            order.OrderId,
            //order.UserId,
            order.CreatedTime,
            new Address(
                order.DeliveryAddress.Id,
                order.DeliveryAddress.Name,
                order.DeliveryAddress.Line1,
                order.DeliveryAddress.Line2,
                order.DeliveryAddress.City,
                order.DeliveryAddress.Region,
                order.DeliveryAddress.PostalCode
            ),
            order.Pizzas.Select(p =>
            {
                var pizzaSpecial = _unitOfWork.PizzaSpecials.GetByGuid(p.Special.Id);
                if (pizzaSpecial == null)
                {
                    pizzaSpecial = new PizzaSpecial(
                        p.Special.Id,
                        p.Special.Name,
                        p.Special.BasePrice,
                        p.Special.Description,
                        p.Special.ImageUrl,
                        p.Special.FixedSize
                    );
                }

                return new Pizza(
                    p.Id,
                    p.OrderId,
                    pizzaSpecial,
                    p.SpecialId,
                    p.Size,
                    p.Toppings.Select(t =>
                    {
                        var topping = _unitOfWork.Toppings.GetByGuid(t.Topping.Id);
                        if (topping == null)
                        {
                            topping = new Topping(
                                t.Topping.Id,
                                t.Topping.Name,
                                t.Topping.Price
                            );
                        }

                        return new PizzaTopping(
                            topping,
                            t.ToppingId,
                            t.PizzaId
                        );
                    }).ToList()
                );
            }).ToList()
        );

        _unitOfWork.Orders.Add(orderEntity);
        _unitOfWork.Complete();

        return Ok(orderEntity.OrderId);
    }

    [HttpDelete("{guid}")]
    public void Delete(Guid guid)
    {
        var orderId = _unitOfWork.Orders.Find(_ => _.OrderId == guid).First();
        _unitOfWork.Orders.Remove(orderId);
        _unitOfWork.Complete();
    }
}
