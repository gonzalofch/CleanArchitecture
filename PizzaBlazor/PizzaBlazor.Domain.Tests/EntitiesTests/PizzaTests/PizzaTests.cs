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

            Pizza pizza = new Pizza(id, special, size, toppings);

            pizza.Id.Should().Be(id);
            pizza.Special.Should().BeEquivalentTo(special);
            pizza.Size.Should().Be(size);
            pizza.Toppings.Should().BeEquivalentTo(toppings);
        }

        [Fact]
        public void Pizza_Should_GetBasePrice_Correctly_Formatted()
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
             new Topping(Guid.NewGuid(), "Pepperoni", 1.50m),
             new Topping(Guid.NewGuid(), "Mushrooms", 1.00m),
             new Topping(Guid.NewGuid(), "Olives", 1.25m),
            };

            Pizza pizza = new Pizza(id, special, size, toppings);

            var basePrice= pizza.GetBasePrice();

            basePrice.Should().Be(16.67M);

        }

        [Fact]
        public void Pizza_Should_GetTotalPrice_Correctly_Formatted()
        {
            var id = Guid.NewGuid();

            var special = new PizzaSpecial()
            {
                Id = Guid.NewGuid(),
                Name = "PizzaPiks",
                BasePrice = 15.0m,
                Description = "Classic pizza",
                ImageUrl = "imageUrl",
                FixedSize = null,
            };

            var size = 15;
            var toppings = new List<Topping>()
            {
             new Topping(Guid.NewGuid(), "Pepperoni", 1.50m),
             new Topping(Guid.NewGuid(), "Mushrooms", 1.00m),
             new Topping(Guid.NewGuid(), "Olives", 1.25m),
            };

            Pizza pizza = new Pizza(id, special, size, toppings);

            var basePrice = pizza.GetTotalPrice();

            basePrice.Should().Be(22.5M);
        }

        [Fact]
        public void Pizza_Should_GetFormattedTotalPrice_Correctly_Formatted()
        {
            var id = Guid.NewGuid();

            var special = new PizzaSpecial()
            {
                Id = Guid.NewGuid(),
                Name = "PizzaPiks",
                BasePrice = 15.0m,
                Description = "Classic pizza",
                ImageUrl = "imageUrl",
                FixedSize = null,
            };

            var size = 15;
            var toppings = new List<Topping>()
            {
             new Topping(Guid.NewGuid(), "Pepperoni", 1.50m),
             new Topping(Guid.NewGuid(), "Mushrooms", 1.00m),
             new Topping(Guid.NewGuid(), "Olives", 1.25m),
            };

            Pizza pizza = new Pizza(id, special, size, toppings);

            var basePrice = pizza.GetFormattedTotalPrice();

            basePrice.Should().Be("22,50");
        }
    }
}
