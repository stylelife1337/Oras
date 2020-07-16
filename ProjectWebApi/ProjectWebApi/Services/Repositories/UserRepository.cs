using ProjectWebApi.Contexts;
using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectWebApi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AtractieContext _context;

        public UserRepository(AtractieContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}