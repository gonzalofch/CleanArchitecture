using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Represents a customized pizza as part of an order
/// </summary>
public class Pizza
{
    public Pizza(Guid id, PizzaSpecial special, Guid specialId, int size, List<Topping> toppings)
    {
        Id = id;
        Special = special;
        SpecialId = specialId;
        Size = size;
        Toppings = toppings;
    }
    public Pizza()
    {
    }

    public const int DefaultSize = 12;
    public const int MinimumSize = 9;
    public const int MaximumSize = 17;

    public Guid Id { get; set; }
    
    public virtual PizzaSpecial Special { get; set; }

    public Guid SpecialId { get; set; }

    public int Size { get; set; }

    public virtual List<Topping> Toppings { get; set; }

    public decimal GetBasePrice() =>
    Special is { FixedSize: not null }
        ? Special.BasePrice
        : (decimal)Size / DefaultSize * Special?.BasePrice ?? 1;

    public decimal GetTotalPrice()
    {
        var toppingsPrice = 0.0m;

        foreach (var topping in Toppings)
        {
            toppingsPrice+= topping.Price;
        }

        return GetBasePrice() + toppingsPrice;
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}