using Microsoft.AspNetCore.Mvc;
using PizzaWeb.Shared.Models;
using PizzaBlazor;

using Domain.UnitOfWork;
using Domain.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public List<OrderDTO> GetOrders()
    {
        return _unitOfWork.Orders.GetAll().ToList()
            ;
        //return OrderService.getAllOrders();
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        _unitOfWork.Orders.Add(OrderDTO); //aqui tendria q pasarle el dto
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _unitOfWork.Orders.Remove(OrderDTO)
    }
}
