using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBlazor.Server.Controllers;

[Route("api/[controller]")]
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
        _.UserId,
        _.CreatedTime,
        new Address(
            _.DeliveryAddress.Id,
            _.DeliveryAddress.Name,
            _.DeliveryAddress.Line1,
            _.DeliveryAddress.Line2,
            _.DeliveryAddress.City,
            _.DeliveryAddress.Region,
            _.DeliveryAddress.PostalCode
        ),
        _.Pizzas.Select(p => new Pizza(
            p.Id,
            p.OrderId,
            new PizzaSpecial(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaTopping(
                new Topping(
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

    [HttpGet("{guid}")]
    public OrderDTO Get(Guid guid)
    {
        var order = _unitOfWork.Orders.GetByGuid(guid);
        return new OrderDTO(
        order.OrderId,
        order.UserId,
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
        order.Pizzas.Select(p => new Pizza(
            p.Id,
            p.OrderId,
            new PizzaSpecial(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaTopping(
                new Topping(
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

    [HttpPost]
    public IActionResult Post(OrderDTO order)
    {
        Order orderEntity = new Order(
        order.OrderId,
        order.UserId,
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
        order.Pizzas.Select(p => new Pizza(
            p.Id,
            p.OrderId,
            new PizzaSpecial(
                p.Special.Id,
                p.Special.Name,
                p.Special.BasePrice,
                p.Special.Description,
                p.Special.ImageUrl,
                p.Special.FixedSize
            ),
            p.SpecialId,
            p.Size,
            p.Toppings.Select(t => new PizzaTopping(
                new Topping(
                    t.Topping.Id,
                    t.Topping.Name,
                    t.Topping.Price
                ),
                t.ToppingId,
                t.PizzaId
            )).ToList()
        )).ToList()
    );
        _unitOfWork.Orders.Add(orderEntity);
        _unitOfWork.Complete();
        return Ok();
    }

    [HttpDelete("{guid}")]
    public void Delete(Guid guid)
    {
        var orderId = _unitOfWork.Orders.Find(_ => _.OrderId == guid).First();
        _unitOfWork.Orders.Remove(orderId);
        _unitOfWork.Complete();
    }
}
