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


public class ToppingServiceTests
{
    private readonly ToppingService _toppingService;
    private readonly IUnitOfWork _unitOfWork= Substitute.For<IUnitOfWork>();

    public ToppingServiceTests()
    {
        _toppingService = new ToppingService(_unitOfWork);
    }

    [Fact]
    public void Should_GetAllToppings()
    {
        var expectedToppings = new List<Topping>()
        {
            new Topping(Guid.NewGuid(), "topping1", 1.10m),
            new Topping(Guid.NewGuid(), "topping2", 1.20m),
            new Topping(Guid.NewGuid(), "topping3", 1.30m),
            new Topping(Guid.NewGuid(), "topping4", 1.40m)
        };

        _unitOfWork.Toppings.GetAll().Returns(expectedToppings);


        var result = _toppingService.GetToppings();

        result.Should().BeEquivalentTo(expectedToppings);
    }

    [Fact]
    public void Should_Add_Topping()
    {
        var toppingInfo = new ToppingCreateInfo("toppingNuevo", 21.00m);
        var topping = toppingInfo.MapToTopping();

        _toppingService.AddTopping(toppingInfo);

        _unitOfWork.Toppings.Received(1).Add(topping);
    }
}
