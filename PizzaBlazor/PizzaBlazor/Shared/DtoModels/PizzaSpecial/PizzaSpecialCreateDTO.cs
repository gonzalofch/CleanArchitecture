namespace PizzaBlazor.Shared.DtoModels.PizzaSpecial
{
    public class PizzaSpecialCreateDTO
    {
        public PizzaSpecialCreateDTO(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
