using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.StateEnums;
using Application.Mappers;
using Application.UseCases.Create;
namespace Application.Mappers;

public static class OrderMapper
{
    public static Order MapToOrderToCreate(this OrderCreateInfo orderInfo)
    {
        return new Order
        {
            OrderId = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            DeliveryAddress = orderInfo.DeliveryAddress.MapToAddressToCreate(),
            //Pizzas = orderInfo.Pizzas.MapToPizzaListToCreate(),
        };
    }
}