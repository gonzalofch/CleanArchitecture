using Application.UseCases.Create;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ToppingMapper
    {
        public static Topping MapToTopping(this ToppingCreateInfo toppingInfo)
        {
            return new Topping()
            {
                Id = Guid.NewGuid(),
                Name = toppingInfo.Name,
                Price = toppingInfo.Price,
            };
        }

        public static List<Topping> MapToToppingList(this List<ToppingCreateInfo> toppings)
        {
            return toppings.Select(topping => topping.MapToTopping()).ToList();
        }

        public static Topping MapToToppingToCreate(this Guid toppingGuid)
        {
            return new Topping()
            {
                Id = toppingGuid, 
            };
        }

        public static List<Topping> MapToToppingListToCreate(this List<Guid> toppings)
        {
            return toppings.Select(topping => topping.MapToToppingToCreate()).ToList();
        }
    }
}
