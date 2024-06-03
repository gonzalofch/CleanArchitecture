using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PizzaTopping
{
    public PizzaTopping(Topping topping, Guid toppingId, Guid pizzaId)
    {
        Topping = topping;
        ToppingId = toppingId;
        PizzaId = pizzaId;
    }

    public PizzaTopping() { }

    public virtual Topping Topping { get; set; } = new Topping();

    public Guid ToppingId { get; set; }

    public Guid PizzaId { get; set; }

    public virtual Pizza Pizza { get; set; }


}