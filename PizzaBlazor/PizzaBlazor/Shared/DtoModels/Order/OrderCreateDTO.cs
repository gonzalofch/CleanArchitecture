using PizzaBlazor.Shared.DtoModels.Address;
using PizzaBlazor.Shared.DtoModels.Pizza;

namespace PizzaBlazor.Shared.DtoModels.Order
{
    public class OrderCreateDTO
    {
        public OrderCreateDTO(/* Guid userId,*/ AddressCreateDTO deliveryAddress, List<PizzaCreateDTO> pizzas)
        {
            //UserId = userId;
            DeliveryAddress = deliveryAddress;
            Pizzas = pizzas;
        }

        public OrderCreateDTO() { }

        //public Guid UserId { get; set; }

        public AddressCreateDTO DeliveryAddress { get; set; } = new AddressCreateDTO();

        public List<PizzaCreateDTO> Pizzas { get; set; } = new List<PizzaCreateDTO>();
    }
}
