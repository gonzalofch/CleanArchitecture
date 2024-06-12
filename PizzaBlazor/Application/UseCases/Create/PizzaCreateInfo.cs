namespace Application.UseCases.Create
{
    public class PizzaCreateInfo
    {
        public PizzaCreateInfo(Guid specialId, int size, List<Guid> toppings)
        {
            SpecialId = specialId;
            Size = size;
            Toppings = toppings;
        }
        public PizzaCreateInfo() { }
        public Guid SpecialId { get; set; }

        public int Size { get; set; }

        public List<Guid> Toppings { get; set; }
    }
}
