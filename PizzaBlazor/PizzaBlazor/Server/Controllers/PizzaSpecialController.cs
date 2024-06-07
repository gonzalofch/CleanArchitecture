using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace PizzaBlazor.Server.Controllers;

[Route("pizzaspecials")]
[ApiController]
public class PizzaSpecialController : ControllerBase
{

    private readonly PizzaSpecialService _pizzaService;
    public PizzaSpecialController(PizzaSpecialService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public IActionResult GetSpecials()
    {
        var specials = _pizzaService.GetPizzaSpecials();
        return Ok(specials);
    }

    [HttpPost]
    public IActionResult AddNewPizza(PizzaSpecialCreateInfo pizza)
    {
        _pizzaService.AddPizzaSpecial(pizza);
        return Ok(pizza);
    }
}
