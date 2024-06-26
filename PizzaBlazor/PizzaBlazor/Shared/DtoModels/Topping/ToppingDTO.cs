﻿namespace PizzaBlazor.Shared.DtoModels.Topping;

public class ToppingDTO
{
    public ToppingDTO(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public ToppingDTO() { }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string GetFormattedPrice() => Price.ToString("0.00");
}
