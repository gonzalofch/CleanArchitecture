//using Domain.UnitOfWork;
//using Domain.Repositories;
//using Domain.Entities;
//using Autofac.Extras.Moq;
//using Castle.Components.DictionaryAdapter.Xml;
//using Moq;
//namespace PizzaBlazor.Application.Tests;

//public class UnitTest1
//{
//    private IUnitOfWork _unitOfWork;
//    public UnitTest1(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    [Fact]
//    public void Should_Add_Orders()
//    {
//        //var id = Guid.NewGuid();
//        //var createdTime = DateTime.Now;
//        //var deliveryAddress = new Address(Guid.NewGuid(), "John Doe", "123 Main St", "Apt 4B", "New York", "NY", "12345");
//        //var pizzas = new List<Pizza> {
//        //    new Pizza(Guid.NewGuid(),
//        //    new PizzaSpecial(Guid.NewGuid(),
//        //                    "Margherita",
//        //                    10.0m,
//        //                    "Classic pizza",
//        //                    "imageUrl",
//        //                    null),
//        //    12,
//        //    new List<Topping>()
//        //    {
//        //     new Topping(Guid.NewGuid(), "Pepperoni", 1.50m),
//        //     new Topping(Guid.NewGuid(), "Mushrooms", 1.00m),
//        //     new Topping(Guid.NewGuid(), "Olives", 1.25m),
//        //    }
//        //    )
//        //};

//        //using (var mock = AutoMock.GetLoose())
//        //{
//        //    Order order = new Order(id, createdTime, deliveryAddress, pizzas);

//        //    mock.Mock<IUnitOfWork>()
//        //        .Setup(x => x.Orders.Add(order));
//        //    var cls = mock.Create<IUnitOfWork>();
//        //    cls.Complete();

//        //    mock.Mock<IUnitOfWork>()
//        //        .Verify(x => x.Orders.Add(order), Times.Exactly(1));

//        //}
//    }
//}