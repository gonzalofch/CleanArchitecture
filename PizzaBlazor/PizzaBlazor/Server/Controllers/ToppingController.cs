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
        private readonly IUnitOfWork _unitOfWork;
        public ToppingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetToppings()
        {
            var toppings = _unitOfWork.Toppings.GetAll().ToList();
            return Ok(toppings);
        }

        [HttpPost]
        public IActionResult AddToppings(ToppingDTO toppingDTO)
        {
            Topping topping = new Topping(toppingDTO.Id, toppingDTO.Name, toppingDTO.Price);
            _unitOfWork.Toppings.Add(topping);
            _unitOfWork.Complete();
            return Ok(topping);
        }
    }
}
