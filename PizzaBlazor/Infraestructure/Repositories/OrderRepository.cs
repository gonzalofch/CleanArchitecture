using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
