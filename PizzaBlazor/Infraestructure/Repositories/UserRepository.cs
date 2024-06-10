using Domain.Entities;
using Domain.Repositories;

namespace Infraestructure.Repositories
{
    public class UserRepository : GenericRepository<UserInfo>, IUserRepository
    {
        public UserRepository(PizzaStoreContext context) : base(context)
        {
        }

        public void Update(object user)
        {
            _context.Update(user);
        }
    }
}
