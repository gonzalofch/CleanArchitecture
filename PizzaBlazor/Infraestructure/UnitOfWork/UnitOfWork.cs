using Domain.Repositories;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Repositories;
using Domain.Entities;

namespace Infraestructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly PizzaStoreContext _context;
    public UnitOfWork(PizzaStoreContext context)
    {
        _context = context;
        Adresses = new AddressRepository(_context);
        Orders = new OrderRepository(_context);
        Pizzas = new PizzaRepository(_context);
        PizzaSpecials = new PizzaSpecialRepository(_context);
        Toppings = new ToppingRepository(_context);
        User = new UserRepository(_context);
    }

    #region Repositories
    public IAddressRepository Adresses { get; private set; }
    public IOrderRepository Orders { get; private set; }
    public IPizzaRepository Pizzas { get; private set; }
    public IPizzaSpecialRepository PizzaSpecials { get; private set; }
    public IToppingRepository Toppings { get; private set; }
    public IUserRepository User { get; private set; }
    #endregion 

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}