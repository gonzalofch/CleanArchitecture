using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record ToppingDTO(Guid id, string name, decimal price)
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
