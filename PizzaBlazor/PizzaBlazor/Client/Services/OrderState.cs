using Domain.UnitOfWork;
using Microsoft.AspNetCore.Components;
using PizzaBlazor.Shared.DtoModels;

namespace PizzaBlazor.Client.Services;
public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public PizzaDTO ConfiguringPizza { get; private set; }
    public OrderDTO Order { get; private set; } = new OrderDTO();

    public void ShowConfigurePizzaDialog(PizzaSpecialDTO special)
    {
        ConfiguringPizza = new PizzaDTO()
        {
            Special = special,
            SpecialId = special.Id,
            Size = PizzaDTO.DefaultSize,
            Toppings = new List<PizzaToppingDTO>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(PizzaDTO pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ResetOrder()
    {
        Order = new OrderDTO();
    }
}