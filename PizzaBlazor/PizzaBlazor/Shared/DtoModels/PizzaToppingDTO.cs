using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels
{
    public class PizzaToppingDTO
    {
        public PizzaToppingDTO(ToppingDTO topping, Guid toppingId, Guid pizzaId)
        {
            Topping = topping;
            ToppingId = toppingId;
            PizzaId = pizzaId;
        }
        public PizzaToppingDTO() { }

        public ToppingDTO Topping { get; set; }

        public Guid ToppingId { get; set; }

        public Guid PizzaId { get; set; }
    }
}
