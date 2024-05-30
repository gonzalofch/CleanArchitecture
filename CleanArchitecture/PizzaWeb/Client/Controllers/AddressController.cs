using AutoMapper;
using PizzaWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
namespace PizzaWeb.Client.Controllers
{
    public class AddressController : Controller
    {
        private static List<Address> addressesList = new List<Address>
            {
                new Address
                {
                    Id = 1,
                    Name = "John Doe",
                    Line1 = "1234 Elm Street",
                    Line2 = "Apt 56",
                    City = "Springfield",
                    Region = "IL",
                    PostalCode = "62704"
                },
                new Address
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Line1 = "5678 Oak Avenue",
                    Line2 = "Suite 101",
                    City = "Metropolis",
                    Region = "NY",
                    PostalCode = "10001"
                },
                new Address
                {
                    Id = 3,
                    Name = "Mike Johnson",
                    Line1 = "9101 Pine Road",
                    Line2 = "",
                    City = "Gotham",
                    Region = "NJ",
                    PostalCode = "07001"
                },
                new Address
                {
                    Id = 4,
                    Name = "Emily Davis",
                    Line1 = "1122 Maple Lane",
                    Line2 = "",
                    City = "Star City",
                    Region = "CA",
                    PostalCode = "90210"
                },
                new Address
                {
                    Id = 5,
                    Name = "Alice Brown",
                    Line1 = "3344 Birch Boulevard",
                    Line2 = "Building B",
                    City = "Central City",
                    Region = "OH",
                    PostalCode = "43210"
                }
                };

        private readonly IMapper _mapper;

        public AddressController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<Address>> GetAddresses()
        {
            //automapper replaces this
            //var addressDto = new AddressDto();
            //addressDto.Name = addressesList[0].Name;
            //addressDto.Line1 = addressesList[0].Line1;
            //addressDto.Line2 = addressesList[0].Line2;
            //addressDto.City = addressesList[0].City;
            //addressDto.Region = addressesList[0].Region;

            return Ok(addressesList.Select(address => _mapper.Map<Address>(address)));
        }

    }
}
