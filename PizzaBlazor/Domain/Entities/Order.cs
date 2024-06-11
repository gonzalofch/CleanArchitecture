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
        DeliveryAddress = Guard.Against.Null(deliveryAddress);
        Pizzas = Guard.Against.Null(pizzas);
    }

    public Guid OrderId { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual Address DeliveryAddress { get; set; }

    public virtual List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    public string GetStatus()
    {
        if (IsPreparing())
        {
            return DispatchTimeState.Preparing.Message;
        }
        else if (IsReady())
        {
            return DispatchTimeState.OutForDelivery.Message;
        }
        else
        {
            return DispatchTimeState.Delivered.Message;
        }
    }

    private static DateTime GetDeliveryTime()
    {
        return GetDeliveryTime().Add(DeliveryDuration);
    }

    public DateTime GetDispatchTime()
    {
        var dispatchTime = CreatedTime.Add(PreparationDuration);
        return dispatchTime;
    }

    public bool IsPreparing()
    {
        return DateTime.Now < GetDispatchTime();
    }

    private static bool IsReady()
    {
        return DateTime.Now < GetDeliveryTime();
    }

    public void AddPizza(PizzaSpecial special, int size, List<Topping> toppings)
    {
        var pizza = new Pizza(Guid.NewGuid(), special, size, toppings);
        Pizzas.Add(pizza);
    }
}