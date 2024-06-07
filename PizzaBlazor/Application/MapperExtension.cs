using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application;

public static class MapperExtension
{
    public static Order MapearAOrderDesdeCreateInfo(this OrderCreateInfo orderInfo)
    {
        return new Order
        {
            OrderId = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            DeliveryAddress = new Address
            {
                Id = Guid.NewGuid(),
                Name = orderInfo.DeliveryAddress.Name,
                Line1 = orderInfo.DeliveryAddress.Line1,
                Line2 = orderInfo.DeliveryAddress.Line2,
                City = orderInfo.DeliveryAddress.City,
                Region = orderInfo.DeliveryAddress.Region,
                PostalCode = orderInfo.DeliveryAddress.PostalCode
            },
            Pizzas = orderInfo.Pizzas.Select(p =>
            {
                return new Pizza
                {
                    Id = Guid.NewGuid(),
                    SpecialId = p.SpecialId,
                    Size = p.Size,
                    Toppings = new List<Topping>()
                };
            }).ToList()
        };
        //queda agregarle la pizzaSpecial escogida y los toppings escogidos de la lista de toppings
    }

    public static PizzaSpecial MapearDesdePizzaSpecialInfo(this PizzaSpecialCreateInfo pizzaSpecialInfo)
    {

        return new PizzaSpecial
        {
            Id = Guid.NewGuid(),
            Name = pizzaSpecialInfo.Name,
            BasePrice = pizzaSpecialInfo.BasePrice,
            Description = pizzaSpecialInfo.Description,
            ImageUrl = pizzaSpecialInfo.ImageUrl,
            FixedSize = pizzaSpecialInfo.FixedSize,
        };
    }

    public static Pizza MapearDesdePizzaInfo(this PizzaCreateInfo pizzaInfo)
    {
        return new Pizza
        {
            Id = Guid.NewGuid(),
            Size = pizzaInfo.Size,
            SpecialId = pizzaInfo.SpecialId,
        };
    }
}

/*public static class MapeadorExtension
{
public static ClaseB MapearAClaseB(this ClaseA claseA)
{
return new ClaseB
{
    PropiedadA = claseA.Propiedad1,
    PropiedadB = claseA.Propiedad2
};
}
}*/