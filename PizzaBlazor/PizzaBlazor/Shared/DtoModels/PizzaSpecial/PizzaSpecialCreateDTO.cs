﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.PizzaSpecial
{
    public class PizzaSpecialCreateDTO
    {
        public PizzaSpecialCreateDTO(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
