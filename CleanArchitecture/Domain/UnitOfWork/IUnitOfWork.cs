using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;

namespace Domain.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IAddressRepository Adresses { get; }
    IOrderRepository Orders { get; }
    IPizzaRepository Pizzas { get; }
    IPizzaToppingRepository PizzaToppings { get; }
    IPizzaSpecialRepository PizzaSpecials{ get; }
    IToppingRepository Toppings { get; }

    public void Dispose();
}
