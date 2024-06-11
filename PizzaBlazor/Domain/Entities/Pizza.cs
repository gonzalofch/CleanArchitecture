using Ardalis.GuardClauses;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Represents a customized pizza as part of an order
/// </summary>
public class Pizza
{
    public Pizza(Guid id, PizzaSpecial special, int size, List<Topping> toppings)
    {
        Id = id;
        Special = Guard.Against.Null(special);
        Size = size;
        Toppings = Guard.Against.Null(toppings);
    }
    public Pizza()
    {
    }

    public const int DefaultSize = 12;
    public const int MinimumSize = 9;
    public const int MaximumSize = 17;

    public Guid Id { get; set; }

    public virtual PizzaSpecial Special { get; set; }

    public int Size { get; set; }

    public virtual List<Topping> Toppings { get; set; } = new List<Topping>();


    public decimal GetBasePrice()
    {
        if (Special.FixedSize is not null)
        {
            return Special.BasePrice;
        }

        return Math.Round((decimal)Size / DefaultSize * Special?.BasePrice ?? 1, 2);
    }

    public decimal GetTotalPrice()
    {
        var toppingsPrice = Toppings.Sum(topping => topping.Price);

        return GetBasePrice() + toppingsPrice;
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}