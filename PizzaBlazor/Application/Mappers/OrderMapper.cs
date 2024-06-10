using Application.UseCases.Create;
using Domain.Entities;
namespace Application.Mappers;

public static class OrderMapper
{
    public static Order MapToOrderToCreate(this OrderCreateInfo orderInfo)
    {
        return new Order
        {
            OrderId = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            DeliveryAddress = orderInfo.DeliveryAddress.MapToAddressToCreate(),
            //Pizzas = orderInfo.Pizzas.MapToPizzaListToCreate(),
        };
    }
}