using Application.UseCases.Create;
using Domain.Entities;

namespace Application.Mappers
{
    public static class PizzaSpecialMapper
    {
        public static PizzaSpecial MapToSpecialToCreate(this PizzaSpecialCreateInfo pizzaSpecialInfo)
        {
            return new PizzaSpecial
            {
                Id = Guid.NewGuid(),
                Name = pizzaSpecialInfo.Name,
                BasePrice = pizzaSpecialInfo.BasePrice,
                Description = pizzaSpecialInfo.Description,
                ImageUrl = pizzaSpecialInfo.ImageUrl,
                FixedSize = pizzaSpecialInfo.FixedSize,
            };
        }
    }
}
