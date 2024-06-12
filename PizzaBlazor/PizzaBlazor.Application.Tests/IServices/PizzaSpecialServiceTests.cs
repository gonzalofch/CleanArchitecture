using Application.Mappers;
using Application.UseCases;
using Application.UseCases.Create;
using Domain.Entities;
using Domain.Repositories;
using Domain.UnitOfWork;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Application.Tests.IServices;

public class PizzaSpecialServiceTests
{
    private PizzaSpecialService _specialService;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public PizzaSpecialServiceTests()
    {
        _specialService = new PizzaSpecialService(_unitOfWork);
    }

    [Fact]
    public void Should_Get_All_Specials()
    {
        var expectedSpecials = new List<PizzaSpecial>
                {
                    new PizzaSpecial { Id = Guid.NewGuid(), Name = "Margherita", BasePrice = 10.0m, Description = "Classic pizza", ImageUrl = "img/pizzas/margherita.jpg", FixedSize = null },
                    new PizzaSpecial { Id = Guid.NewGuid(), Name = "Pepperoni", BasePrice = 12.0m, Description = "Pepperoni pizza", ImageUrl = "img/pizzas/pepperoni.jpg", FixedSize = null }
                };

        _unitOfWork.PizzaSpecials.GetAll().Returns(expectedSpecials);


        // Act
        var result = _specialService.GetPizzaSpecials();

        // Assert

        result.Should().BeEquivalentTo(expectedSpecials, options => options);

    }

    [Fact]
    public void Should_Add_PizzaSpecial()
    {
        var special = new PizzaSpecialCreateInfo("PizzaSpecial", 12, "pizzamondongo", "img/pizzas/pizza.jpg", null);

        _specialService.AddPizzaSpecial(special);

        _unitOfWork.PizzaSpecials.Received(1).Add(special.MapToSpecialToCreate());
    }

    [Fact]
    public void Should_Not_Add5_Pizzas()
    {
        var listaPizzas = new List<PizzaSpecial>(){
            new PizzaSpecialCreateInfo("PizzaSpecial", 12, "pizzamondongo", "img/pizzas/pizza.jpg", null).MapToSpecialToCreate(),
            new PizzaSpecialCreateInfo("Pepperoni", 12.0m, "Pepperoni pizza with spicy pepperoni slices", "img/pizzas/pepperoni.jpg", null).MapToSpecialToCreate(),
            new PizzaSpecialCreateInfo("Hawaiian", 11.5m, "Pizza with ham and pineapple", "img/pizzas/hawaiian.jpg", null).MapToSpecialToCreate(),
            new PizzaSpecialCreateInfo("Veggie", 9.0m, "Vegetarian pizza with a variety of vegetables", "img/pizzas/veggie.jpg", null).MapToSpecialToCreate(),
            new PizzaSpecialCreateInfo("BBQ Chicken", 13.5m, "Barbecue chicken pizza with BBQ sauce", "img/pizzas/bbqchicken.jpg", null).MapToSpecialToCreate(),
        };

        _unitOfWork.PizzaSpecials.AddRange(listaPizzas);

        _unitOfWork.PizzaSpecials.Received(1).AddRange(listaPizzas);
    }
}
