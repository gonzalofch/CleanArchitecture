using Application.UseCases;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;
using PizzaBlazor.Shared.DtoModels.Topping;

namespace PizzaBlazor.Server.Controllers
{
    [Route("toppings")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _toppingService;
        public ToppingController(ToppingService toppingService)
        {
            _toppingService = toppingService;
        }

        [HttpGet]
        public IActionResult GetToppings()
        {
            var toppings =_toppingService.GetToppings();
            return Ok(toppings);
        }

        [HttpPost]
        public IActionResult AddToppings(ToppingCreateInfo topping)
        {
            _toppingService.AddTopping(topping);
            return Ok(topping);
        }
    }
}
