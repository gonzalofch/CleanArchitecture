﻿using Domain.Entities;
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
            p.Toppings.Select(t => new ToppingDTO(
                    t.Id,
                    t.Name,
                    t.Price
            )).ToList()
        )).ToList()
    )).ToList();

        return Ok(orders);
    }

    [HttpPost]
    public IActionResult Post(OrderCreateDTO order)
    {
        var allToppings = _unitOfWork.Toppings.GetAll().ToDictionary(t => t.Id);
        var allPizzaSpecials = _unitOfWork.PizzaSpecials.GetAll().ToDictionary(ps => ps.Id);

        // OrderCreateDTO a Order
        var orderEntity = new Order
        {
            OrderId = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            DeliveryAddress = new Address
            {
                Id = Guid.NewGuid(),
                Name = order.DeliveryAddress.Name,
                Line1 = order.DeliveryAddress.Line1,
                Line2 = order.DeliveryAddress.Line2,
                City = order.DeliveryAddress.City,
                Region = order.DeliveryAddress.Region,
                PostalCode = order.DeliveryAddress.PostalCode
            },
            Pizzas = order.Pizzas.Select(p =>
            {
                var pizzaSpecial = allPizzaSpecials.GetValueOrDefault(p.SpecialId) ?? new PizzaSpecial();
                return new Pizza
                {
                    Id = Guid.NewGuid(),
                    SpecialId = pizzaSpecial.Id,
                    Size = p.Size,
                    Special = pizzaSpecial,
                    Toppings = p.Toppings
                               .Where(tpngId => allToppings.ContainsKey(tpngId))
                               .Select(tpngId => allToppings[tpngId])
                               .ToList()
                };
            }).ToList()
        };

        _unitOfWork.Orders.Add(orderEntity);
        _unitOfWork.Complete();

        return Ok(orderEntity.OrderId);
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
            p.Toppings.Select(t => new ToppingDTO(
                    t.Id,
                    t.Name,
                    t.Price
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
            p.Toppings.Select(t => new ToppingDTO(
                    t.Id,
                    t.Name,
                    t.Price
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
            p.Toppings.Select(t => new ToppingDTO(
                    t.Id,
                    t.Name,
                    t.Price
            )).ToList()
        )).ToList());

        if (order == null)
        {
            return NotFound();
        }

        return Ok(OrderWithStatusDTO.FromOrder(orderDto));
    }

    [HttpDelete("{guid}")]
    public void Delete(Guid guid)
    {
        var orderId = _unitOfWork.Orders.Find(_ => _.OrderId == guid).First();
        _unitOfWork.Orders.Remove(orderId);
        _unitOfWork.Complete();
    }
}
