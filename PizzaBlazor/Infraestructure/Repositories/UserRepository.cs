﻿using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
