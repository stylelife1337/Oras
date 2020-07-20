using ProjectWebApi.Contexts;
using ProjectWebApi.Services.Repositories;
using System;


namespace ProjectWebApi.Services.UnitsOfWork
{
    public class AtractieUnitOfWork : IAtractieUnitOfWork
    {
        private readonly AtractieContext _context;

        public AtractieUnitOfWork(AtractieContext context, IAtractieRepository attractions,
            IOrasRepository cities)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Attractions = attractions ?? throw new ArgumentNullException(nameof(context));
            Cities = cities ?? throw new ArgumentNullException(nameof(context));
        }

        public IAtractieRepository Attractions { get; }

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
