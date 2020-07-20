using ProjectWebApi.Contexts;
using ProjectWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public class OrasUnitOfWork : IOrasUnitOfWork
    {
        private readonly AtractieContext _context;

        public OrasUnitOfWork(AtractieContext context, IOrasRepository cities,
            ITaraRepository countries)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Cities = cities ?? throw new ArgumentNullException(nameof(context));
            Countries = countries ?? throw new ArgumentNullException(nameof(context));
        }

        public IOrasRepository Cities { get; }

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
