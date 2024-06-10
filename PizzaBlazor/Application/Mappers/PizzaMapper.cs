using Application.UseCases.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class PizzaMapper
    {
        public static Pizza MapToPizzaToCreate(this PizzaCreateInfo pizzaInfo)
        {
            return new Pizza
            {
                Id = Guid.NewGuid(),
                Size = pizzaInfo.Size,
                SpecialId = pizzaInfo.SpecialId,
                Toppings = pizzaInfo.Toppings.MapToToppingListToCreate()
            };
        }

        public static List<Pizza> MapToPizzaListToCreate(this List<PizzaCreateInfo> pizzaListInfo)
        {
            return pizzaListInfo.Select(pizzaInfo=> pizzaInfo.MapToPizzaToCreate()).ToList();
        }
    }
}