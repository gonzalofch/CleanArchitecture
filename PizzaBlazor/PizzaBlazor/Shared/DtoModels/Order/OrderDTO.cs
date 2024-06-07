using Domain.StateEnums;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Pizza;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.Order
{
    public class OrderDTO
    {
        public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
        public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);
        public OrderDTO(Guid orderId,/* Guid userId,*/ DateTime createdTime, AddressDTO deliveryAddress, List<PizzaDTO> pizzas)
        {
            OrderId = orderId;
            //UserId = userId;
            CreatedTime = createdTime;
            DeliveryAddress = deliveryAddress;
            Pizzas = pizzas;
        }

        public OrderDTO() { }

        public Guid OrderId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public AddressDTO DeliveryAddress { get; set; } = new AddressDTO();

        public List<PizzaDTO> Pizzas { get; set; } = new List<PizzaDTO>();
        
        public string StatusText { get; set; }

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
}
