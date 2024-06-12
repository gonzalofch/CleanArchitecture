using Application.UseCases.Create;
using Domain.Entities;
using Domain.UnitOfWork;

namespace Application.UseCases
{
    public class ToppingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToppingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTopping(ToppingCreateInfo topping)
        {
            var newTopping = new Topping(Guid.NewGuid(), topping.Name, topping.Price);
            _unitOfWork.Toppings.Add(newTopping);
            _unitOfWork.Complete();
        }

        public List<Topping> GetToppings()
        {
            var toppings = _unitOfWork.Toppings.GetAll().ToList();
            return toppings;
        }
    }
}
