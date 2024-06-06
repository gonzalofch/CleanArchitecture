using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;

namespace PizzaBlazor.Server.Controllers;

[Route("orderwithstatus")]
[ApiController]
public class OrderWithStatusController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderWithStatusController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
