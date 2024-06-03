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

    int Complete();

    public void Dispose();
}
