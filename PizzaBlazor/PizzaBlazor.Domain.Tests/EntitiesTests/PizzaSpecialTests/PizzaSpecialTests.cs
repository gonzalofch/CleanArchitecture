using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.PizzaSpecialTests
{
    public class PizzaSpecialTests
    {
        [Fact]
        public void Should_Create_PizzaSpecial_With_Valid_Properties()
        {
            var id = Guid.NewGuid();
            var name = "Nombre";
            var basePrice = 100.00m;
            var description = "pizza muuy rica";
            var imageUrl = "img/pizzas/blabla.jpg"; //agregar verificacion en clase de ruta correcta
            var fixedSize = 12;
         
            PizzaSpecial pizzaSpecial = new PizzaSpecial(id,name,basePrice,description,imageUrl,fixedSize);

            pizzaSpecial.Id.Should().Be(id);
            pizzaSpecial.Name.Should().Be(name);
            pizzaSpecial.BasePrice.Should().Be(basePrice);
            //terminar esta validacion
        }
    }
}
