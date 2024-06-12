using Application.UseCases.Create;
using Domain.Entities;
using Domain.UnitOfWork;
namespace Application.UseCases
{
    public class PizzaSpecialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaSpecialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPizzaSpecial(PizzaSpecialCreateInfo pizza)
        {
            var newPizza = new PizzaSpecial(Guid.NewGuid(), pizza.Name,
                pizza.BasePrice, pizza.Description, pizza.ImageUrl, pizza.FixedSize);
            _unitOfWork.PizzaSpecials.Add(newPizza);
            _unitOfWork.Complete();
        }

        public List<PizzaSpecial> GetPizzaSpecials()
        {
            var specials = _unitOfWork.PizzaSpecials.GetAll().ToList();
            return specials;
        }
    }
}
