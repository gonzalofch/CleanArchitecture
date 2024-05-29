namespace DataAccessBlazor;


public class Order
{

    public Order(/*int? orderId = 1, string? userId = "11", DateTime? createdTime = null, Address? address = null*/)
    {
        //OrderId = orderId ?? 1;
        //UserId = userId ?? "11";
        //CreatedTime = createdTime ?? DateTime.Now;
        //DeliveryAddress = address ?? new Address
        //{
        //    Id = 1,
        //    Name = "Casa",
        //    Line1 = "123 Calle Principal",
        //    Line2 = "Piso 2",
        //    City = "Ciudad",
        //    Region = "Región",
        //    PostalCode = "12345"
        //};
    }

    public int OrderId { get; set; }

    public string UserId { get; set; }

    public DateTime CreatedTime { get; set; }

    public Address DeliveryAddress { get; set; } = new Address();
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
}