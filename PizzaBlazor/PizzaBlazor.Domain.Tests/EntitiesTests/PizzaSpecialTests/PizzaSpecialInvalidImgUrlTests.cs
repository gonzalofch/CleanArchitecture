using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.PizzaSpecialTests;

public class PizzaSpecialInvalidImgUrlTests : IEnumerable<object[]>
{
    public readonly List<object[]> data = new List<object[]>()
    {
        new object[]{//1
            PizzaSpecial.DinamicSize(Guid.NewGuid(),"nombre",10.00m,"pizzaSpecial","img/drinks/margarita.jpg")
        },
        new object[]{//2
            PizzaSpecial.DinamicSize(Guid.NewGuid(),"nombre",10.00m,"pizzaSpecial","img/pizzas/margarita.png")
        },
        new object[]{//3
            PizzaSpecial.DinamicSize(Guid.NewGuid(),"nombre",10.00m,"pizzaSpecial","")
        },
        new object[]{//4
            PizzaSpecial.DinamicSize(Guid.NewGuid(),"nombre",10.00m,"pizzaSpecial","img/pizzas/margarita .jpg")
        },
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }
}
