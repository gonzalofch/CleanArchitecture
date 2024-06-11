using Application.Mappers;
using Application.UseCases.Create;
using Domain.Entities;
using Domain.UnitOfWork;

namespace Application.UseCases
{
    public class OrderService
    {
        private IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid AddOrder(OrderCreateInfo orderInfo)
        {
            var availableToppings = _unitOfWork.Toppings.GetAll().ToDictionary(t => t.Id);
            var availablePizzaSpecials = _unitOfWork.PizzaSpecials.GetAll().ToDictionary(ps => ps.Id);

            Order order = orderInfo.MapToOrderToCreate();

            orderInfo.Pizzas.ForEach(pizza =>
                        {
                            PizzaSpecial pizzaSpecial = availablePizzaSpecials.GetValueOrDefault(pizza.SpecialId) ?? new PizzaSpecial();

                            List<Topping> toppings = pizza.Toppings
                                        .Where(toppingId => availableToppings.ContainsKey(toppingId))
                                        .Select(toppingId => availableToppings[toppingId])
                                        .ToList();

                            order.AddPizza(pizzaSpecial, pizza.Size, toppings);
                        });
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complete();

            return order.OrderId;
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
