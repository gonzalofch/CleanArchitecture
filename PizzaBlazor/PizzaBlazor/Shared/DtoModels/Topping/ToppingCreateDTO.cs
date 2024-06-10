namespace PizzaBlazor.Shared.DtoModels.Topping
{
    public  class ToppingCreateDTO
    {
        public ToppingCreateDTO(Guid id)
        {
            Id = id;
        }

        public ToppingCreateDTO() { }

        public Guid Id { get; set; }
    }
}
