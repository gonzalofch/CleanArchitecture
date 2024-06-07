using Domain.StateEnums;

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

    public virtual List<Pizza> Pizzas { get; set; }
    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");

    public string GetStatus()
    {
        string statusText;
        var dispatchTime = DateTime.Now.Add(PreparationDuration);

        if (DateTime.Now < dispatchTime)
        {
            statusText = DispatchTimeState.Preparing.Message;
        }
        else if (DateTime.Now < dispatchTime + DeliveryDuration)
        {
            statusText = DispatchTimeState.OutForDelivery.Message;
        }
        else
        {
            statusText = DispatchTimeState.Delivered.Message;
        }

        return statusText;
    }
}