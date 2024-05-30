using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    internal class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
