namespace Application.UseCases
{
    public class OrderCreateInfo
    {
        public OrderCreateInfo(AddressCreateInfo deliveryAddress, List<PizzaCreateInfo> pizzas)
        {
            DeliveryAddress = deliveryAddress;
            Pizzas = pizzas;
        }


        public AddressCreateInfo DeliveryAddress { get; set; }

        public List<PizzaCreateInfo> Pizzas { get; set; }
    }
}