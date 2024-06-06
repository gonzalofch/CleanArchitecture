using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Shared.DtoModels.Topping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.Pizza
{
    public class PizzaCreateDTO
    {
        public PizzaCreateDTO(Guid specialId, int size, List<Guid> toppings)
        {
            SpecialId = specialId;
            Size = size;
            Toppings = toppings;
        }
        public PizzaCreateDTO() { }

        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public Guid SpecialId { get; set; }

        public int Size { get; set; }

        public List<Guid> Toppings { get; set; }
    }
}
