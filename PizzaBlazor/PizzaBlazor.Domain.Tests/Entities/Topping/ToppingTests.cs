using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.ToppingTests
{
    public class ToppingTests
    {
        [Fact]
        public void Should_Create_Topping_With_Valid_Properties()
        {
            var id = Guid.NewGuid();
            var name = "topping1";
            var price = 15.00m;

            Topping topping = new Topping(id, name, price);
            topping.Id.Should().Be(id);
            topping.Name.Should().Be(name);
            topping.Price.Should().Be(price);
        }
        [Fact]
        public void Should_Throw_Exception_If_Topping_Name_Is_Not_Valid()
        {
            var invalidName = "";

            FluentActions
                .Invoking(() => new Topping(Guid.NewGuid(), invalidName, 5m))
                .Should().Throw<ArgumentException>()
                .WithMessage("Required input name was empty. (Parameter 'name')");
        }

        [Fact]
        public void Should_Throw_Exception_If_Topping_Price_Is_Not_Valid()
        {
            var invalidPrice = -1m;

            FluentActions
                .Invoking(() => new Topping(Guid.NewGuid(), "Cheese", invalidPrice))
                .Should().Throw<ArgumentException>().WithMessage("Required input price cannot be zero or negative. (Parameter 'price')");
        }

        [Fact]
        public void Should_Get_Formatted_Price()
        {
            var id = Guid.NewGuid();
            var name = "topping1";
            var price = 15.00m;

            Topping topping = new Topping(id, name, price);
            topping.GetFormattedPrice().Should().Be("15,00");
        }
    }
}
