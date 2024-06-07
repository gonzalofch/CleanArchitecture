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
            var orderEntity = new Order
            {
                OrderId = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeliveryAddress = new Address
                {
                    Id = Guid.NewGuid(),
                    Name = order.DeliveryAddress.Name,
                    Line1 = order.DeliveryAddress.Line1,
                    Line2 = order.DeliveryAddress.Line2,
                    City = order.DeliveryAddress.City,
                    Region = order.DeliveryAddress.Region,
                    PostalCode = order.DeliveryAddress.PostalCode
                },
                Pizzas = order.Pizzas.Select(p =>
                {
                    var pizzaSpecial = allPizzaSpecials.GetValueOrDefault(p.SpecialId) ?? new PizzaSpecial();
                    return new Pizza
                    {
                        Id = Guid.NewGuid(),
                        SpecialId = pizzaSpecial.Id,
                        Size = p.Size,
                        Special = pizzaSpecial,
                        Toppings = p.Toppings
                                   .Where(tpngId => allToppings.ContainsKey(tpngId))
                                   .Select(tpngId => allToppings[tpngId])
                                   .ToList()
                    };
                }).ToList()
            };

            _unitOfWork.Orders.Add(orderEntity);
            _unitOfWork.Complete();
            return orderEntity.OrderId;
        }

        public OrderWithStatus GetOrderWithStatus(Guid orderId)
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

            return OrderWithStatus.FromOrder(orderDto);

        }
        public List<OrderWithStatus> GetAllOrdersWithStatus()
        {
            var orders = _unitOfWork.Orders.GetAll();
            var ordersWithStatus = orders.Select(orderDto => OrderWithStatus.FromOrder(orderDto)).ToList();
            return ordersWithStatus;
        }
    }
}
