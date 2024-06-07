using PizzaBlazor.Shared.DtoModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels
{
    public class OrderWithStatusDTO
    {
        public OrderWithStatusDTO() { }

        public OrderWithStatusDTO(OrderDTO order, string statusText)
        {
            Order = order;
            StatusText = statusText;
        }

        public virtual OrderDTO Order { get; set; }

        public string StatusText { get; set; }
    }
}
