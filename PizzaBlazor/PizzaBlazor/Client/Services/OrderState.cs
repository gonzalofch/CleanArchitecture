using Microsoft.AspNetCore.Components;
using PizzaBlazor.Shared.DtoModels;
using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Order;
using PizzaBlazor.Shared.DtoModels.Pizza;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Shared.DtoModels.Topping;

namespace PizzaBlazor.Client.Services;
public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public PizzaDTO ConfiguringPizza { get; private set; }
    public List<ToppingDTO> SelectedToppings { get; private set; }
    public OrderDTO Order { get; private set; } =
        new OrderDTO(Guid.NewGuid(),/*Guid.NewGuid(),*/DateTime.Now, new AddressDTO(), new List<PizzaDTO>());
    public OrderCreateDTO OrderCreation { get; private set; } = new OrderCreateDTO(new AddressCreateDTO(), new List<PizzaCreateDTO>());

    public OrderState()
    {

    }

    public void ShowConfigurePizzaDialog(PizzaSpecialDTO special)
    {
        ConfiguringPizza = new PizzaDTO(Guid.NewGuid(), special, special.Id, PizzaDTO.DefaultSize, new List<ToppingDTO>());

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }
    public void RemoveConfiguredPizza(PizzaDTO pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ConfirmConfigurePizzaDialog()
    {
        PizzaCreateDTO pizzaToCreate = new(ConfiguringPizza.SpecialId, ConfiguringPizza.Size, ConfiguringPizza.Toppings.Select(t => t.Id).ToList());
        Order.Pizzas.Add(ConfiguringPizza);
        OrderCreation.Pizzas.Add(pizzaToCreate);
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ResetOrder()
    {
        Order = new OrderDTO();
        OrderCreation = new OrderCreateDTO();
    }

    //TOPPINGS
    public void InitializeToppings(List<ToppingDTO> toppings)
    {
        SelectedToppings = toppings;
    }






}