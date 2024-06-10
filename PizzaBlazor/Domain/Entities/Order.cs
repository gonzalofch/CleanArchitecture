using Domain.StateEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Order
{
    public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
    public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);

    public Order() { }

    public Order(Guid orderId, /*Guid userId,*/ DateTime createdTime, Address deliveryAddress, List<Pizza> pizzas)
    {
        OrderId = orderId;
        CreatedTime = createdTime;
        DeliveryAddress = deliveryAddress;
        Pizzas = pizzas;
    }

    public Guid OrderId { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual Address DeliveryAddress { get; set; }

    public virtual List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    public string GetStatus()
    {
        string statusText;
        var dispatchTime = CreatedTime.Add(PreparationDuration);

        if (CreatedTime < dispatchTime)
        {
            statusText = DispatchTimeState.Preparing.Message;
        }
        else if (CreatedTime < dispatchTime + DeliveryDuration)
        {
            statusText = DispatchTimeState.OutForDelivery.Message;
        }
        else
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
            throw new ValidationException("Delivery address is required.");
        }

        if (Pizzas == null || !Pizzas.Any())
        {
            throw new ValidationException("At least one pizza is required.");
        }
    }
}