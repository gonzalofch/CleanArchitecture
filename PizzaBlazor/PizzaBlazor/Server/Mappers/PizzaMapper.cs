using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Pizza;

namespace PizzaBlazor.Server.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDTO MapToDTO(this Pizza pizza)
        {
            return new PizzaDTO(pizza.Id, pizza.Special.MapToDTO(), pizza.Size, pizza.Toppings.MapToDTOList());
        }

        public static List<PizzaDTO> MapToDTOList(this List<Pizza> pizzas)
        {
            return pizzas.Select(pizza => pizza.MapToDTO()).ToList();
        }
    }
}