using ProjectWebApi.Contexts;
using ProjectWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public class CazareUnitOfWork : ICazareUnitOfWork
    {
        private readonly AtractieContext _context;

        public CazareUnitOfWork(AtractieContext context, ICazareRepository bookings,
            IOrasRepository cities)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Bookings = bookings ?? throw new ArgumentNullException(nameof(context));
            Cities = cities ?? throw new ArgumentNullException(nameof(context));
        }

        public ICazareRepository Bookings { get; }

        public IOrasRepository Cities { get; }

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
