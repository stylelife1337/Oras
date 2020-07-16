using ProjectWebApi.Contexts;
using ProjectWebApi.Services.Repositories;
using System;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly AtractieContext _context;

        public UserUnitOfWork(AtractieContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Users = users ?? throw new ArgumentNullException(nameof(context));
        }

        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
