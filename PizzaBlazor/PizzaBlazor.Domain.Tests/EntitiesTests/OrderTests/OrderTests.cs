using Domain.Entities;
using Domain.StateEnums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.OrderTests;

public class OrderTests
{
    [Fact]
    public void Should_Create_Order_With_Valid_Properties()
    {
        var id = Guid.NewGuid();
        var createdTime = DateTime.Now;
        var deliveryAddress = new Address(Guid.NewGuid(), "John Doe", "123 Main St", "Apt 4B", "New York", "NY", "12345");
        var pizzas = new List<Pizza> {
            new Pizza(Guid.NewGuid(),
            new PizzaSpecial(Guid.NewGuid(),
                            "Margherita",
                            10.0m,
                            "Classic pizza",
                            "imageUrl",
                            null),
            12,
            new List<Topping>())
        };

        Order order = new Order(id, createdTime, deliveryAddress, pizzas);

        order.OrderId.Should().Be(id);
        order.CreatedTime.Should().BeCloseTo(createdTime, TimeSpan.FromSeconds(1));
        order.DeliveryAddress.Should().Be(deliveryAddress);
        order.Pizzas.Should().BeEquivalentTo(pizzas);
    }

    [Fact]
    public void GetTotalPrice_Should_Return_Correct_Total_Price()
    {
        var pizzas = new List<Pizza>
        {
            new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null), 12, new List<Topping>()),
            new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Pepperoni", 12.0m, "Pepperoni pizza", "imageUrl", null), 12, new List<Topping>())
        };

        var order = new Order(Guid.NewGuid(), DateTime.Now, new Address(), pizzas);

        var totalPrice = order.GetTotalPrice();

        totalPrice.Should().Be(22.0m);
    }

    [Fact]
    public void GetFormattedTotalPrice_Should_Return_Correct_Formatted_Price()
    {
        var pizzas = new List<Pizza>
        {
            new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null), 12, new List<Topping>())
        };
        var order = new Order(Guid.NewGuid(), DateTime.Now, new Address(), pizzas);

        var formattedPrice = order.GetFormattedTotalPrice();

        formattedPrice.Should().Be("10,00");
    }

    [Fact]
    public void GetStatus_Should_Return_Preparing_If_CreatedTime_Is_Less_Than_DispatchTime()
    {
        var createdTime = DateTime.Now.AddMinutes(-10);
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());

        var status = order.GetStatus();

        status.Should().Be(DispatchTimeState.Preparing.Message);
    }

    [Fact]
    public void GetStatus_Should_Return_OutForDelivery_If_CreatedTime_Is_Less_Than_DeliveryTime()
    {
        var createdTime = DateTime.Now;
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());
        order.CreatedTime = createdTime.AddMinutes(12);
        var status = order.GetStatus();

        status.Should().Be(DispatchTimeState.OutForDelivery.Message);
    }

    [Fact]
    public void GetStatus_Should_Return_Delivered_If_CreatedTime_Is_Greater_Than_DeliveryTime()
    {
        var createdTime = DateTime.Now;
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());
        order.CreatedTime = createdTime.AddSeconds(30);
        var status = order.GetStatus();

        status.Should().Be(DispatchTimeState.Delivered.Message);
    }

    [Fact]
    public void AddPizza_Should_Add_Pizza_To_Order()
    {
        var order = new Order(Guid.NewGuid(), DateTime.Now, new Address(), new List<Pizza>());
        var special = new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null);
        var size = 12;
        var toppings = new List<Topping> { new Topping { Id = Guid.NewGuid(), Name = "Mushrooms", Price = 2.0m } };

        order.AddPizza(special, size, toppings);

        order.Pizzas.Should().HaveCount(1);
        var pizza = order.Pizzas[0];
        pizza.Special.Should().Be(special);
        pizza.Size.Should().Be(size);
        pizza.Toppings.Should().BeEquivalentTo(toppings);
    }

    [Fact]
    public void Should_Throw_Exception_If_Order_Has_No_Pizzas()
    {
        var id = Guid.NewGuid();
        var createdTime = DateTime.Now;
        var deliveryAddress = new Address()
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Line1 = "Main St",
            Line2 = "Apt 4B",
            City = "New York",
            Region = "New York Region",
            PostalCode = "12345",
        };

        List<Pizza> pizzas = null;

        //Order order = new Order()
        //{
        //    OrderId = id,
        //    CreatedTime = createdTime,
        //    DeliveryAddress = deliveryAddress,
        //    Pizzas = pizzas
        //};

        FluentActions
            .Invoking(() => new Order(id, createdTime, deliveryAddress, pizzas))
            .Should().Throw<ArgumentException>()
            .WithMessage("Value cannot be null. (Parameter 'pizzas')");
    }

    [Fact]
    public void Should_Throw_Exception_If_Order_Is_Not_Valid_No_DeliveryAddress()
    {
        var orderId = Guid.NewGuid();
        var createdTime = DateTime.Now;
        Address deliveryAddress = null;
        var pizzas = new List<Pizza>
            {
                new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null), 12, new List<Topping>())
            };
        
        FluentActions
            .Invoking(() => new Order(orderId,createdTime,deliveryAddress,pizzas))
            .Should().Throw<Exception>()
            .WithMessage("The DeliveryAddress cannot be null.");
    }
}
