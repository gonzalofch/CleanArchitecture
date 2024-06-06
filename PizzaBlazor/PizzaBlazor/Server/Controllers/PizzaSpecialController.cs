using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;

namespace PizzaBlazor.Server.Controllers;

[Route("pizzaspecials")]
[ApiController]
public class PizzaSpecialController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public PizzaSpecialController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetSpecials()
    {
        var specials = _unitOfWork.PizzaSpecials.GetAll().ToList();
        return Ok(specials);
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public IActionResult GetSpecial(Guid guid)
    {
        var special = _unitOfWork.PizzaSpecials.GetByGuid(guid);
        return Ok(special);
    }

    [HttpPost]
    public IActionResult AddNewPizza(PizzaSpecialDTO pizza)
    {
        var newPizza = new PizzaSpecial(pizza.Id, pizza.Name, pizza.BasePrice, pizza.Description, pizza.ImageUrl, pizza.FixedSize);
        _unitOfWork.PizzaSpecials.Add(newPizza);
        _unitOfWork.Complete();
        return Ok(newPizza);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid guid)
    {
        var removedPizza = _unitOfWork.PizzaSpecials.Find(p => p.Id == guid).First();
        _unitOfWork.PizzaSpecials.Remove(removedPizza);
        return Ok(removedPizza);
    }
}
