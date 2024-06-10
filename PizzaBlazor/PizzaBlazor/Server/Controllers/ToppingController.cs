using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
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
        public List<ToppingDTO> GetToppings()
        {
            var toppings =_toppingService.GetToppings();
            List<ToppingDTO> toppingsDTO = toppings.Select(x =>
            {
                return new ToppingDTO(x.Id, x.Name, x.Price);
            }).ToList();

            return toppingsDTO;
        }
    }
}
