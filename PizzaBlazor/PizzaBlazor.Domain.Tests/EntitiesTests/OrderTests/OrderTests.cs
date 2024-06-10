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
    public void Should_Throw_Exception_If_Order_Is_Not_Valid()
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
        var createdTime = DateTime.Now;
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());

        var status = order.GetStatus();

        status.Should().Be(DispatchTimeState.Preparing.Message);
    }

    [Fact]
    public void GetStatus_Should_Return_OutForDelivery_If_CreatedTime_Is_Less_Than_DeliveryTime()
    {
        var createdTime = DateTime.Now.Subtract(Order.PreparationDuration).AddSeconds(5);
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());

        var status = order.GetStatus();

        status.Should().Be(DispatchTimeState.OutForDelivery.Message);
    }

    [Fact]
    public void GetStatus_Should_Return_Delivered_If_CreatedTime_Is_Greater_Than_DeliveryTime()
    {
        var createdTime = DateTime.Now.Subtract(Order.PreparationDuration).Subtract(Order.DeliveryDuration).Subtract(TimeSpan.FromSeconds(5));
        var order = new Order(Guid.NewGuid(), createdTime, new Address(), new List<Pizza>());

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
    public void Should_Throw_Exception_If_Order_Is_Not_Valid_No_DeliveryAddress()
    {
        var order = new Order
        {
            CreatedTime = DateTime.Now,
            Pizzas = new List<Pizza>
            {
                new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null), 12, new List<Topping>())
            }
        };

        Action act = () => order.Validate();

        act.Should().Throw<ValidationException>().WithMessage("Delivery address is required.");
    }

    [Fact]
    public void Should_Throw_Exception_If_Order_Is_Not_Valid_No_Pizzas()
    {
        var order = new Order
        {
            CreatedTime = DateTime.Now,
            DeliveryAddress = new Address(Guid.NewGuid(), "John Doe", "123 Main St", "Apt 4B", "New York", "NY", "12345")
        };

        Action act = () => order.Validate();

        act.Should().Throw<ValidationException>().WithMessage("At least one pizza is required.");
    }

    [Fact]
    public void Should_Not_Throw_Exception_If_Order_Is_Valid()
    {
        var order = new Order
        {
            CreatedTime = DateTime.Now,
            DeliveryAddress = new Address(Guid.NewGuid(), "John Doe", "123 Main St", "Apt 4B", "New York", "NY", "12345"),
            Pizzas = new List<Pizza>
            {
                new Pizza(Guid.NewGuid(), new PizzaSpecial(Guid.NewGuid(), "Margherita", 10.0m, "Classic pizza", "imageUrl", null), 12, new List<Topping>())
            }
        };

        Action act = () => order.Validate();

        act.Should().NotThrow<ValidationException>();
    }
}
