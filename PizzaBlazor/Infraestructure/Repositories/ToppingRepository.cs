using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class ToppingRepository : GenericRepository<Topping>, IToppingRepository
    {
        public ToppingRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
