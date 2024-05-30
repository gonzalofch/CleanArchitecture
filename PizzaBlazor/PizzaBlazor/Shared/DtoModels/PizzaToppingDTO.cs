using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record PizzaToppingDTO(ToppingDTO topping, Guid toppingId, Guid pizzaId)
    {
        //public ToppingDTO Topping { get; set; }

        //public int ToppingId { get; set; }

        //public int PizzaId { get; set; }
    }
}
