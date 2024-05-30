using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record AddressDTO(string name, string line1, string line2, string city, string region)
    {
        public string Name { get; set; } = string.Empty;

        public string Line1 { get; set; } = string.Empty;
        
        public string Line2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

    }
}
