using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record  PizzaDTO (Guid id, Guid orderId,PizzaSpecialDTO special,Guid specialId, int size, List<PizzaToppingDTO> toppings)
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public PizzaSpecialDTO Special { get; set; }

        public int SpecialId { get; set; }

        public int Size { get; set; }

        public List<PizzaToppingDTO> Toppings { get; set; }
    }
}
