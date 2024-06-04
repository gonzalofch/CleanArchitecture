namespace Domain.Entities;


public class Order
{

    public Order(Guid orderId, /*Guid userId,*/ DateTime createdTime, Address deliveryAddress, List<Pizza> pizzas)
    {
        OrderId = orderId;
        CreatedTime = createdTime;
        DeliveryAddress = deliveryAddress;
        Pizzas = pizzas;
    }

    public Order() { }

    public Guid OrderId { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual Address DeliveryAddress { get; set; }
    public virtual List<Pizza> Pizzas { get; set; } 
        
    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
}   