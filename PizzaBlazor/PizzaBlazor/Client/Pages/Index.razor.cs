using Microsoft.AspNetCore.Components;
using PizzaBlazor.Client.Services;
using PizzaBlazor.Shared.DtoModels.Order;
using PizzaBlazor.Shared.DtoModels.PizzaSpecial;
using PizzaBlazor.Shared.DtoModels.Topping;
using System.Net.Http.Json;

namespace PizzaBlazor.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] OrderState OrderStateInstance { get; set; }

        public List<PizzaSpecialDTO> specials { get; set; }
        public List<ToppingDTO> selectableToppings { get; set; }
        public OrderDTO order => OrderStateInstance.Order;

        private void NavigateToPaymentPage()
        {
            NavigationManager.NavigateTo("buypizza");
        }

        protected override async Task OnInitializedAsync()
        {
            selectableToppings = await HttpClient.GetFromJsonAsync<List<ToppingDTO>>(NavigationManager.BaseUri + "toppings");
            specials = await HttpClient.GetFromJsonAsync<List<PizzaSpecialDTO>>(NavigationManager.BaseUri + "pizzaspecials");
        }
    }
}
