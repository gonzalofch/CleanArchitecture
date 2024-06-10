using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;

namespace PizzaBlazor.Server.Mappers
{
    public static class PizzaSpecialMapper
    {
        public static PizzaSpecialDTO MapToDTO(this PizzaSpecial special)
        {
            return new PizzaSpecialDTO()
            {
                Id = special.Id,
                Name = special.Name,
                BasePrice = special.BasePrice,
                Description = special.Description,
                ImageUrl = special.ImageUrl,
                FixedSize = special.FixedSize
            };
        }

        public static List<PizzaSpecialDTO> MapToDTOList(this List<PizzaSpecial> specials)
        {
            return specials.Select(x => x.MapToDTO()).ToList();
        }
    }
}