using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Create
{
    public class PizzaCreateInfo
    {
        public PizzaCreateInfo(Guid specialId, int size, List<Guid> toppings)
        {
            SpecialId = specialId;
            Size = size;
            Toppings = toppings;
        }

        public Guid SpecialId { get; set; }

        public int Size { get; set; }

        public List<Guid> Toppings { get; set; }
    }
}
