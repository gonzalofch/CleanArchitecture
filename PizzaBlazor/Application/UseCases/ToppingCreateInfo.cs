using System.ComponentModel.DataAnnotations;

namespace Application.UseCases
{
    public class ToppingCreateInfo
    {
        public ToppingCreateInfo(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}