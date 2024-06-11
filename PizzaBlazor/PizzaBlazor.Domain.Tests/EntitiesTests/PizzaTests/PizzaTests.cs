using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.PizzaTests
{
    public class PizzaTests
    {
        [Fact]
        public void Should_Create_Pizza_With_Valid_Properties()
        {
            var id = Guid.NewGuid();

            var special = new PizzaSpecial()
            {
                Id = Guid.NewGuid(),
                Name = "Margherita",
                BasePrice = 10.0m,
                Description = "Classic pizza",
                ImageUrl = "imageUrl",
                FixedSize = null,
            };

            var size = 20;
            var toppings = new List<Topping>()
            {
                new Topping(),
                new Topping(),
                new Topping(),
            };

            Pizza pizza= new Pizza(id,special,size,toppings);

            pizza.Id.Should().Be(id);
            pizza.Special.Should().BeEquivalentTo(special);
            pizza.Size.Should().Be(size);
            pizza.Toppings.Should().BeEquivalentTo(toppings);
        }
    }

}
