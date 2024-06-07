namespace Domain.Entities;

public class OrderWithStatus
{
    public virtual Order Order { get; set; }

    public string StatusText { get; set; }

    public OrderWithStatus(Order order, string statusText)
    {
        Order = order;
        StatusText = statusText;
    }
}