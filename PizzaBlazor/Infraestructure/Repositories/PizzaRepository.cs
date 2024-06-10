using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
