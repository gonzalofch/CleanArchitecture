using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.Topping
{
    public  class ToppingCreateDTO
    {
        public ToppingCreateDTO(Guid id)
        {
            Id = id;
        }
        public ToppingCreateDTO() { }

        public Guid Id { get; set; }
    }
}
