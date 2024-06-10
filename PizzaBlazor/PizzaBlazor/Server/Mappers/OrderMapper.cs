using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Order;
using System.Runtime.CompilerServices;

namespace PizzaBlazor.Server.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO MapToDTO(this Order order)
        {
            OrderDTO orderDTO = new OrderDTO();

            orderDTO.OrderId = order.OrderId;
            orderDTO.CreatedTime = order.CreatedTime;
            orderDTO.DeliveryAddress = order.DeliveryAddress.MapToDTO();
            orderDTO.Pizzas = order.Pizzas.Select(pizza =>
            {
                return pizza.MapToDTO();
            }).ToList();
            orderDTO.StatusText = order.GetStatus();

            return orderDTO;
        }

        public static List<OrderDTO> MapToDTOList(this List<Order> orders)
        {
            return orders.Select(order => order.MapToDTO()).ToList();
        }
    }
}
