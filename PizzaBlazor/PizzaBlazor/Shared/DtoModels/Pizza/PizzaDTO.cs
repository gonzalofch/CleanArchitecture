using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Shared.DtoModels.Topping;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels.Pizza
{
    public class PizzaDTO
    {
        public PizzaDTO(Guid id, PizzaSpecialDTO special, Guid specialId, int size, List<ToppingDTO> toppings)
        {
            Id = id;
            Special = special;
            SpecialId = specialId;
            Size = size;
            Toppings = toppings;
        }
        public PizzaDTO() { }

        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;
        public Guid Id { get; set; }

        public PizzaSpecialDTO Special { get; set; }

        public Guid SpecialId { get; set; }

        public int Size { get; set; }

        public List<ToppingDTO> Toppings { get; set; }

        public decimal GetBasePrice() =>
        Special is { FixedSize: not null }
            ? Special.BasePrice
            : (decimal)Size / DefaultSize * Special?.BasePrice ?? 1;

        public decimal GetTotalPrice()
        {
            var toppingsPrice = 0.0m;

            foreach (var topping in Toppings)
            {
                toppingsPrice += topping.Price;
            }

            return GetBasePrice() + toppingsPrice;
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }

    }

}
