using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record  PizzaDTO (Guid Id, Guid OrderId, PizzaSpecialDTO Special, Guid SpecialId, int Size, List<PizzaToppingDTO> Toppings)
    {
    }
}
