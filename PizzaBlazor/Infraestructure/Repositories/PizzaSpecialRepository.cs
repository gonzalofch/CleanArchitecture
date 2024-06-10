using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class PizzaSpecialRepository : GenericRepository<PizzaSpecial>, IPizzaSpecialRepository
    {
        public PizzaSpecialRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
