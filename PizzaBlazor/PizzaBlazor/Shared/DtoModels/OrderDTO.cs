using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record OrderDTO(Guid OrderId, Guid UserId, DateTime CreatedTime, AddressDTO DeliveryAddress, List<PizzaDTO> Pizzas);

}
