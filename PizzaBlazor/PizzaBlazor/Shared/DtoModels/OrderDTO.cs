using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record OrderDTO(Guid orderId, Guid userId, DateTime createdTime, AddressDTO deliveryAddress, List<PizzaDTO> pizzas)
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public AddressDTO DeliveryAddress { get; set; } 

        public List<PizzaDTO> Pizzas { get; set; } = new List<PizzaDTO>();
    }
}
