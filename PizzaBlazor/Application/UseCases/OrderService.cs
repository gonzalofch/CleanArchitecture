using Domain.Entities;
using Domain.UnitOfWork;
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
            var allToppings = _unitOfWork.Toppings.GetAll().ToDictionary(t => t.Id);
            var allPizzaSpecials = _unitOfWork.PizzaSpecials.GetAll().ToDictionary(ps => ps.Id);
            var orderEntity = MapperExtension.MapearAOrderDesdeCreateInfo(order);

            orderEntity.Pizzas = order.Pizzas.Select(p =>
                {
                    var pizzaSpecial = allPizzaSpecials.GetValueOrDefault(p.SpecialId) ?? new PizzaSpecial();
                    var pizza = MapperExtension.MapearDesdePizzaInfo(p);
                    return new Pizza
                    {
                        Special = pizzaSpecial,
                        Toppings = p.Toppings
                                   .Where(tpngId => allToppings.ContainsKey(tpngId))
                                   .Select(tpngId => allToppings[tpngId])
                                   .ToList()
                    };
                }).ToList();

            _unitOfWork.Orders.Add(orderEntity);
            _unitOfWork.Complete();
            return orderEntity.OrderId;
        }

        public Order GetOrderWithStatus(Guid orderId)
        {
            var order = _unitOfWork.Orders
    .Find(o => o.OrderId == orderId).First();
            var orderDto = new Order(
            order.OrderId,
            //order.UserId,
            order.CreatedTime,
            new Address(
                order.DeliveryAddress.Id,
                order.DeliveryAddress.Name,
                order.DeliveryAddress.Line1,
                order.DeliveryAddress.Line2,
                order.DeliveryAddress.City,
                order.DeliveryAddress.Region,
                order.DeliveryAddress.PostalCode
            ),
            order.Pizzas.Select(p => new Pizza(
                p.Id,
                new PizzaSpecial(
                    p.Special.Id,
                    p.Special.Name,
                    p.Special.BasePrice,
                    p.Special.Description,
                    p.Special.ImageUrl,
                    p.Special.FixedSize
                ),
                p.SpecialId,
                p.Size,
                p.Toppings.Select(t => new Topping(
                        t.Id,
                        t.Name,
                        t.Price
                )).ToList()
            )).ToList());

            return orderDto;

        }
        public List<Order> GetAllOrdersWithStatus()
        {
            var orders = _unitOfWork.Orders.GetAll().ToList();
            return orders;
        }
    }
}
