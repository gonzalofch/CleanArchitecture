using Application.UseCases;
using Application.UseCases.Create;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Server.Mappers;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
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
