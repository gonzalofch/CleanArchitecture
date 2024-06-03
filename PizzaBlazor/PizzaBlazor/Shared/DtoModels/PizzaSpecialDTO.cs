﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public record PizzaSpecialDTO(Guid Id, string Name, decimal BasePrice, string Description, string ImageUrl, int? FixedSize)
    {
    }
}
