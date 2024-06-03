using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record AddressDTO(Guid Id, string Name, string Line1, string Line2, string City, string Region, string PostalCode)
    {
    }
}
