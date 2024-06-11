using Ardalis.GuardClauses;
using Domain.StateEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Order
{
    public readonly static TimeSpan PreparationDuration = TimeSpan.FromMinutes(10);
    public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(5);

    public Order() { }

    public Order(Guid orderId, DateTime createdTime, Address deliveryAddress, List<Pizza> pizzas)
    {
        OrderId = orderId;
        CreatedTime = createdTime;
        DeliveryAddress = deliveryAddress;
        Pizzas = Guard.Against.Null(pizzas);
        Validate();
    }

    public Guid OrderId { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual Address DeliveryAddress { get; set; }

    public virtual List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    public string GetStatus()
    {
        string statusText = string.Empty;
        var dispatchTime = CreatedTime.Add(PreparationDuration);


        if (CreatedTime > dispatchTime && CreatedTime < dispatchTime + DeliveryDuration)
        {
            statusText = DispatchTimeState.OutForDelivery.Message;
        }

        if (CreatedTime < dispatchTime)
        {
            statusText = DispatchTimeState.Preparing.Message;
        }

        if (CreatedTime > (dispatchTime + DeliveryDuration))
        {
            statusText = DispatchTimeState.Delivered.Message;
        }

        return statusText;
    }

    public void AddPizza(PizzaSpecial special, int size, List<Topping> toppings)
    {
        var pizza = new Pizza(Guid.NewGuid(), special, size, toppings);
        Pizzas.Add(pizza);
    }
    public void Validate()
    {
        if (DeliveryAddress == null)
        {
            throw new ArgumentException("The DeliveryAddress cannot be null.");
        }
    }


}