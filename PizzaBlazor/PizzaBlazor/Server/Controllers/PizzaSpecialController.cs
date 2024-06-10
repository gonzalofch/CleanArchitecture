using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Server.Mappers;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Application.UseCases.Create;
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
    public List<PizzaSpecialDTO> GetSpecials()
    {
        List<PizzaSpecial> specials = _pizzaService.GetPizzaSpecials();
        return specials.MapToDTOList();
    }

    [HttpPost]
    public IActionResult AddNewPizza(PizzaSpecialCreateInfo pizza)
    {
        _pizzaService.AddPizzaSpecial(pizza);
        return Ok(pizza);
    }
}
