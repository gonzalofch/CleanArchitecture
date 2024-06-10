using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.PizzaSpecial
{
    public class PizzaSpecialDTO
    {
        public PizzaSpecialDTO(Guid id, string name, decimal basePrice, string description, string imageUrl, int? fixedSize)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
            Description = description;
            ImageUrl = imageUrl;
            FixedSize = fixedSize;
        }
        public PizzaSpecialDTO() { }

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal BasePrice { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int? FixedSize { get; set; }

        public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
    }
}
