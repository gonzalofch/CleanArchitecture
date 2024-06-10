using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Order;
using System.Runtime.CompilerServices;

namespace PizzaBlazor.Server.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO MapToDTO(this Order order)
        {
            return new OrderDTO()
            {
                OrderId = order.OrderId,
                CreatedTime = order.CreatedTime,
                DeliveryAddress = order.DeliveryAddress.MapToDTO(),
                Pizzas = order.Pizzas.Select(pizza =>
                {
                    return pizza.MapToDTO();
                }).ToList(),
                StatusText = order.GetStatus(),
            };
        }

        public static List<OrderDTO> MapToDTOList(this List<Order> orders)
        {
            return orders.Select(order => order.MapToDTO()).ToList();
        }
    }
}
