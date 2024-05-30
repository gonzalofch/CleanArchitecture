using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
