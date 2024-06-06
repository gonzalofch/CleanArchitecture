using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Pizza;

namespace PizzaBlazor.Shared.DtoModels.Order
{
    public class OrderCreateDTO
    {
        public OrderCreateDTO(/* Guid userId,*/ AddressCreateDTO deliveryAddress, List<PizzaCreateDTO> pizzas)
        {
            //UserId = userId;
            DeliveryAddress = deliveryAddress;
            Pizzas = pizzas;
        }

        public OrderCreateDTO() { }

        //public Guid UserId { get; set; }

        public AddressCreateDTO DeliveryAddress { get; set; }

        public List<PizzaCreateDTO> Pizzas { get; set; }
    }
}
