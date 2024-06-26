﻿using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
namespace Domain.Entities;

public class Topping
{
    public Topping(Guid id, string name, decimal price)
    {
        Id = id;
        Name = Guard.Against.NullOrEmpty(name);
        Price = Guard.Against.NegativeOrZero(price);
    }

    public Topping() { }

    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string GetFormattedPrice() => Price.ToString("0.00");
}