using Ardalis.GuardClauses;
using System.Text.RegularExpressions;

namespace Domain.Entities;

/// <summary>
/// Represents a pre-configured template for a pizza a user can order
/// </summary>
public class PizzaSpecial
{
    public PizzaSpecial(Guid id, string name, decimal basePrice, string description, string imageUrl, int? fixedSize)
    {
        Id = id;
        Name = Guard.Against.NullOrEmpty(name);
        BasePrice = Guard.Against.NegativeOrZero(basePrice);
        Description = description;
        ImageUrl = imageUrl;
        FixedSize = fixedSize;
    }

    public static PizzaSpecial DinamicSize(Guid id, string name, decimal basePrice, string description, string imageUrl)
    {
        return new PizzaSpecial(id, name, basePrice, description, imageUrl, null);
    }

    public PizzaSpecial() { }

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal BasePrice { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int? FixedSize { get; set; }

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");

    public void Validate()
    {
        IsValidImgUrl();
    }
    public void IsValidImgUrl()
    {
        // Expresión regular para validar el formato
        string pattern = @"^img/pizzas/[a-zA-Z0-9]+\.(jpg)$";

        // Validar el formato utilizando Regex.IsMatch
        if (!Regex.IsMatch(ImageUrl, pattern))
        {
            throw new ArgumentException("The image url is not correct");
        }
    }
}