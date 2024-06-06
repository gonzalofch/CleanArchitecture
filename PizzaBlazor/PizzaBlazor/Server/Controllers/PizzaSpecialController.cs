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

    private readonly PizzaService _pizzaService;
    public PizzaSpecialController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public IActionResult GetSpecials()
    {
        var specials = _pizzaService.GetPizzaSpecials();
        return Ok(specials);
    }

    //// GET api/<ValuesController>/5
    //[HttpGet("{id}")]
    //public IActionResult GetSpecial(Guid guid)
    //{
    //    var special = _unitOfWork.PizzaSpecials.GetByGuid(guid);
    //    return Ok(special);
    //}

    [HttpPost]
    public IActionResult AddNewPizza(PizzaSpecialCreateInfo pizza)
    {
        _pizzaService.AddPizzaSpecial(pizza);
        return Ok(pizza);
    }

    // DELETE api/<ValuesController>/5
    //[HttpDelete("{id}")]
    //public IActionResult Delete(Guid guid)
    //{
    //    var removedPizza = _unitOfWork.PizzaSpecials.Find(p => p.Id == guid).First();
    //    _unitOfWork.PizzaSpecials.Remove(removedPizza);
    //    return Ok(removedPizza);
    //}
}
