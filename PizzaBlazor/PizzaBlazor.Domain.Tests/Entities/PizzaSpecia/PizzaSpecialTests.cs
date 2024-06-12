using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var imageUrl = "img/pizzas/blabla.jpg";
            var fixedSize = 12;

            PizzaSpecial pizzaSpecial = new PizzaSpecial(id, name, basePrice, description, imageUrl, fixedSize);

            pizzaSpecial.Id.Should().Be(id);
            pizzaSpecial.Name.Should().Be(name);
            pizzaSpecial.BasePrice.Should().Be(basePrice);
            pizzaSpecial.Description.Should().Be(description);
            pizzaSpecial.ImageUrl.Should().Be(imageUrl);
            pizzaSpecial.FixedSize.Should().Be(fixedSize);
        }

        [Fact]
        public void Should_GetFormattedBasePrice_Correctly_Formatted()
        {
            var id = Guid.NewGuid();
            var name = "Nombre";
            var basePrice = 100.00m;
            var description = "pizza muuy rica";
            var imageUrl = "img/pizzas/blabla.jpg";
            var fixedSize = 12;

            PizzaSpecial pizzaSpecial = new PizzaSpecial(id, name, basePrice, description, imageUrl, fixedSize);
            var formattedPrice = pizzaSpecial.GetFormattedBasePrice();

            formattedPrice.Should().Be("100,00");
        }

        [Fact]
        public void Should_Return_DinamicSized_Pizza()
        {
            var id = Guid.NewGuid();
            var name = "nombrePizza";
            var basePrice = 10;
            var description = "Nice Pizzaaaaa";
            var imageUrl = "img/pizzas/nombrepizza.jpg";

            var pizzaSpecial = PizzaSpecial.DinamicSize(id, name, basePrice, description, imageUrl);

            pizzaSpecial.Id.Should().Be(id);
            pizzaSpecial.Name.Should().Be(name);
            pizzaSpecial.BasePrice.Should().Be(basePrice);
            pizzaSpecial.Description.Should().Be(description);
            pizzaSpecial.ImageUrl.Should().Be(imageUrl);
            pizzaSpecial.FixedSize.Should().BeNull();
        }

        [Theory]
        [ClassData(typeof(PizzaSpecialImgUrlTests))]
        public void Should_Be_Valid_ImageUrls(PizzaSpecial pizzaSpecial)
        {
            FluentActions
                .Invoking(() => pizzaSpecial.Validate())
                .Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [ClassData(typeof(PizzaSpecialInvalidImgUrlTests))]
        public void Should_Throw_Exception_Invalid_ImageUrls(PizzaSpecial pizzaSpecial)
        {
            FluentActions
                            .Invoking(() => pizzaSpecial.Validate())
                            .Should().Throw<ArgumentException>()
                            .WithMessage("The image url is not correct");
        }
    }
}
