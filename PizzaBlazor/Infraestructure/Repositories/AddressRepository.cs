using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
