﻿using Application.UseCases.Create;
using Domain.Entities;

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
                Toppings = pizzaInfo.Toppings.MapToToppingListToCreate()
            };
        }

        public static List<Pizza> MapToPizzaListToCreate(this List<PizzaCreateInfo> pizzaListInfo)
        {
            return pizzaListInfo.Select(pizzaInfo=> pizzaInfo.MapToPizzaToCreate()).ToList();
        }
    }
}