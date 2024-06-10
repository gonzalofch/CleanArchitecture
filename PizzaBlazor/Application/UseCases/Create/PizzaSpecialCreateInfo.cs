namespace Application.UseCases.Create
{
    public class PizzaSpecialCreateInfo
    {

        public PizzaSpecialCreateInfo(string name, decimal basePrice, string description, string imageUrl, int? fixedSize)
        {
            Name = name;
            BasePrice = basePrice;
            Description = description;
            ImageUrl = imageUrl;
            FixedSize = fixedSize;
        }

        public string Name { get; set; } = string.Empty;

        public decimal BasePrice { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int? FixedSize { get; set; }
    }
}
