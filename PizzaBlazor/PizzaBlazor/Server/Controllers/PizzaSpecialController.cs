using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;

namespace PizzaBlazor.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PizzaSpecialController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public PizzaSpecialController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public List<Pizza> GetPizzas()
    {
        return _unitOfWork.Pizzas.GetAll().ToList();
        //return OrderService.getAllOrders();
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public IActionResult AddNewPizza(PizzaSpecialDTO pizza)
    {
        var newPizza = new PizzaSpecial(pizza.Id, pizza.Name, pizza.BasePrice, pizza.Description, pizza.ImageUrl, pizza.FixedSize);
        _unitOfWork.PizzaSpecials.Add(newPizza);
        return Ok();
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid guid)
    {
        var removedPizza = _unitOfWork.PizzaSpecials.Find(p => p.Id== guid).First();
        _unitOfWork.PizzaSpecials.Remove(removedPizza);
        return Ok(removedPizza);
    }
}
