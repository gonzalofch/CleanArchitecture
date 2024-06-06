using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Order;
using PizzaBlazor.Shared.DtoModels.Pizza;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;


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


    //    [HttpGet]
    //    public IActionResult GetOrders()
    //    {
    //        var orders = _unitOfWork.Orders.GetAll()
    //    .Select(_ => new OrderDTO(
    //        _.OrderId,
    //        //_.UserId,
    //        _.CreatedTime,
    //        new AddressDTO(
    //            _.DeliveryAddress.Id,
    //            _.DeliveryAddress.Name,
    //            _.DeliveryAddress.Line1,
    //            _.DeliveryAddress.Line2,
    //            _.DeliveryAddress.City,
    //            _.DeliveryAddress.Region,
    //            _.DeliveryAddress.PostalCode
    //        ),
    //        _.Pizzas.Select(p => new PizzaDTO(
    //            p.Id,
    //            new PizzaSpecialDTO(
    //                p.Special.Id,
    //                p.Special.Name,
    //                p.Special.BasePrice,
    //                p.Special.Description,
    //                p.Special.ImageUrl,
    //                p.Special.FixedSize
    //            ),
    //            p.SpecialId,
    //            p.Size,
    //            p.Toppings.Select(t => new ToppingDTO(
    //                    t.Id,
    //                    t.Name,
    //                    t.Price
    //            )).ToList()
    //        )).ToList()
    //    )).ToList();

    //        return Ok(orders);
    //    }

    [HttpPost]
    public IActionResult Post(OrderCreateInfo order)
    {
        var orderId = _orderService.AddOrder(order);
        return Ok(orderId);
    }

    //    [HttpGet("details/{guid}")]
    //    public OrderDTO GetOrder(Guid guid)
    //    {
    //        var order = _unitOfWork.Orders.GetByGuid(guid);
    //        return new OrderDTO(
    //        order.OrderId,
    //        //order.UserId,
    //        order.CreatedTime,
    //        new AddressDTO(
    //            order.DeliveryAddress.Id,
    //            order.DeliveryAddress.Name,
    //            order.DeliveryAddress.Line1,
    //            order.DeliveryAddress.Line2,
    //            order.DeliveryAddress.City,
    //            order.DeliveryAddress.Region,
    //            order.DeliveryAddress.PostalCode
    //        ),
    //        order.Pizzas.Select(p => new PizzaDTO(
    //            p.Id,
    //            new PizzaSpecialDTO(
    //                p.Special.Id,
    //                p.Special.Name,
    //                p.Special.BasePrice,
    //                p.Special.Description,
    //                p.Special.ImageUrl,
    //                p.Special.FixedSize
    //            ),
    //            p.SpecialId,
    //            p.Size,
    //            p.Toppings.Select(t => new ToppingDTO(
    //                    t.Id,
    //                    t.Name,
    //                    t.Price
    //                    )).ToList()
    //        )).ToList()
    //    );
    //    }

    [HttpGet("status")]
    public IActionResult GetOrdersWithStatus()
    {
        var allOrdersWithStatus = _orderService.GetAllOrdersWithStatus();
        return Ok(allOrdersWithStatus); //queda recibir undto
    }

    [HttpGet("status/{orderId}")]
public IActionResult GetOrderWithStatus(Guid orderId)
{
    var orderStatus = _orderService.GetOrderWithStatus(orderId);
    return Ok(orderStatus);
}

    //    [HttpDelete("{guid}")]
    //    public void Delete(Guid guid)
    //    {
    //        var orderId = _unitOfWork.Orders.Find(_ => _.OrderId == guid).First();
    //        _unitOfWork.Orders.Remove(orderId);
    //        _unitOfWork.Complete();
    //    }
}
