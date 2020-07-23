using ProjectWebApi.Contexts;
using ProjectWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public class TaraUnitOfWork : ITaraUnitOfWork
    {
        private readonly AtractieContext _context;

        public TaraUnitOfWork(AtractieContext context, ITaraRepository countries)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Countries = countries ?? throw new ArgumentNullException(nameof(context));
        }

        public ITaraRepository Countries { get; }

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
