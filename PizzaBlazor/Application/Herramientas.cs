using Application.Mappers;
using Application.UseCases.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class Herramientas
    {
        public static void FillIOrdernfo(this Order order, OrderCreateInfo orderInfo, Dictionary<Guid, Topping> allToppings, Dictionary<Guid, PizzaSpecial> allPizzaSpecials)
        {

            order.Pizzas = orderInfo.Pizzas.Select(pizza =>
            {
                //definir que pizza es la encontrada
                PizzaSpecial pizzaSpecial = allPizzaSpecials.GetValueOrDefault(pizza.SpecialId) ?? new PizzaSpecial();
                //darle los valores a pizza de esta pizza special encontrada y demas
                List<Topping> toppings = pizza.Toppings
                                .Where(toppingId => allToppings.ContainsKey(toppingId))
                                .Select(toppingId => allToppings[toppingId])
                                .ToList();
                {
                    Pizza pizzaToOrder = pizza.MapToPizzaToCreate();
                    pizzaToOrder.Special = pizzaSpecial;
                    pizzaToOrder.Toppings = toppings;
                    return pizzaToOrder;
                }
            }).ToList();
        }
    }
}
