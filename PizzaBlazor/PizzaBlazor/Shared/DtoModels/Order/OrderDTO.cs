using Domain.Entities;
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

        //public Guid UserId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public AddressDTO DeliveryAddress { get; set; }

        public List<PizzaDTO> Pizzas { get; set; }

        public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");

    }

}
