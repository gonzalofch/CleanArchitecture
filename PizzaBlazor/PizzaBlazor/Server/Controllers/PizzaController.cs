//using Domain.Entities;
//using Domain.UnitOfWork;
//using Microsoft.AspNetCore.Mvc;
//using PizzaWeb.Shared.Models;

//namespace PizzaBlazor.Server.Controllers;
//[Route("api/[controller]")]
//[ApiController]
//public class PizzaController : ControllerBase
//{
//    private readonly IUnitOfWork _unitOfWork;
//    public PizzaController(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    // GET: api/<ValuesController>
//    [HttpGet]
//    public List<Pizza> GetPizzas()
//    {
//        return _unitOfWork.Pizzas.GetAll().ToList();
//        //return OrderService.getAllOrders();
//    }

//    // GET api/<ValuesController>/5
//    [HttpGet("{id}")]
//    public string Get(int id)
//    {
//        return "value";
//    }

//    // POST api/<ValuesController>
//    [HttpPost]
//    public void Post([FromBody] string value)
//    {
//        _unitOfWork.Orders.Add(PizzaDTO); //aqui tendria q pasarle el dto
//    }

//    // DELETE api/<ValuesController>/5
//    [HttpDelete("{id}")]
//    public void Delete(int id)
//    {
//        _unitOfWork.Orders.Remove(PizzaDTO)
//    }
//}
