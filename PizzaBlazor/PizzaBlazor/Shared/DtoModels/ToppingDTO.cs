using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record ToppingDTO(Guid Id, string Name, decimal Price)
    {
    }
}
