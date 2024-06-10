using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Topping;
using System.Runtime.CompilerServices;

namespace PizzaBlazor.Server.Mappers
{
    public static class ToppingsMapper
    {
        public static ToppingDTO MapToDTO(this Topping topping)
        {
            return new ToppingDTO()
            {
                Id = topping.Id,
                Name = topping.Name,
                Price = topping.Price
            };
        }

        public static List<ToppingDTO> MapToDTOList(this List<Topping> toppings)
        {
            return toppings.Select(topping => topping.MapToDTO()).ToList();
        }
    }
}