using Application.Mappers;
using Application.UseCases.Create;
using Domain.Entities;
using Domain.UnitOfWork;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class OrderService
    {
        private IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid AddOrder(OrderCreateInfo order)
        {
            var availableToppings = _unitOfWork.Toppings.GetAll().ToDictionary(t => t.Id);
            var availablePizzaSpecials = _unitOfWork.PizzaSpecials.GetAll().ToDictionary(ps => ps.Id);

            Order orderEntity = order.MapToOrderToCreate();

            order.Pizzas.ForEach(pizza =>
                        {
                            PizzaSpecial pizzaSpecial = availablePizzaSpecials.GetValueOrDefault(pizza.SpecialId) ?? new PizzaSpecial();

                            List<Topping> toppings = pizza.Toppings
                                        .Where(toppingId => availableToppings.ContainsKey(toppingId))
                                        .Select(toppingId => availableToppings[toppingId])
                                        .ToList();

                            orderEntity.AddPizza(pizzaSpecial, pizza.Size, toppings);
                        });
            _unitOfWork.Orders.Add(orderEntity);
            _unitOfWork.Complete();

            return orderEntity.OrderId;
        }

        public Order GetOrderWithStatus(Guid orderId)
        {
            return _unitOfWork.Orders
            .Find(o => o.OrderId == orderId)
                    .First();
        }

        public List<Order> GetAllOrdersWithStatus()
        {
            return _unitOfWork.Orders.GetAll().ToList();
        }
    }
}
