﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWeb.Shared.Models
{
    public class PizzaSpecial
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BasePrice { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? FixedSize { get; set; }
    }
}
