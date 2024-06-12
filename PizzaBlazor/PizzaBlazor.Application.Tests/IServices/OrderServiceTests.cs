using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Application.UseCases;
using Application.UseCases.Create;
using NSubstitute.Core;
using NSubstitute;
using Domain.Entities;
using Domain.UnitOfWork;
using Application.Mappers;
using FluentAssertions;
namespace PizzaBlazor.Application.Tests.IServices;

public class OrderServiceTests
{
    private readonly OrderService _orderService;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    public OrderServiceTests(IUnitOfWork unitOfWork)
    {
        _orderService = new OrderService(unitOfWork);
    }

    [Fact]
    public void AddOrder_Should_Add_Order_And_Complete_UnitOfWork()
    {
        var availableToppings = new List<Topping>
        {
            new Topping { Id = Guid.NewGuid(), Price = 1.0m },
            new Topping { Id = Guid.NewGuid(), Price = 1.5m }
        };
        var availablePizzaSpecials = new List<PizzaSpecial>
        {
            new PizzaSpecial { Id = Guid.NewGuid(), BasePrice = 10.0m }
        };

        _unitOfWork.Toppings.GetAll().Returns(availableToppings);
        _unitOfWork.PizzaSpecials.GetAll().Returns(availablePizzaSpecials);

        var orderInfo = new OrderCreateInfo
        {
            Pizzas = new List<PizzaCreateInfo>
            {
                new PizzaCreateInfo
                {
                    SpecialId = availablePizzaSpecials.First().Id,
                    Size = 12,
                    Toppings = availableToppings.Select(t => t.Id).ToList()
                }
            }
        };

        var expectedOrderId = Guid.NewGuid();
        var expectedPizzaSpecialId = Guid.NewGuid();
        var topping1 = Guid.NewGuid();
        var topping2 = Guid.NewGuid();
        var topping3 = Guid.NewGuid();

        var expectedAddress = new AddressCreateInfo("Gonzalo", "Miguel", "Flores", "Chuchon", "region", "39008");
        var expectedPizza = new PizzaCreateInfo(expectedPizzaSpecialId, 20, new List<Guid>() {
                                                                    topping1,
                                                                    topping2,
                                                                    topping3});
        var order = new OrderCreateInfo { DeliveryAddress = expectedAddress, Pizzas = expectedPizza };

        var result = _orderService.AddOrder(orderInfo);

        _unitOfWork.Orders.Add(orderInfo.MapToOrderToCreate());

        result.Should().Be(expectedOrderId);
    }
}
