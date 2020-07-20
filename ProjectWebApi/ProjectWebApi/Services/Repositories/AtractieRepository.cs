using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Contexts;
using ProjectWebApi.Entities;
using System;
using System.Linq;


namespace ProjectWebApi.Services.Repositories
{
    public class AtractieRepository : Repository<Atractie>, IAtractieRepository
    {
        private readonly AtractieContext _context;

        public AtractieRepository(AtractieContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Atractie GetAtractieDetails(Guid AtractieId)
        {
            return _context.Attractions
                .Where(a => a.Id == AtractieId && (a.Deleted == false || a.Deleted == null))
                .Include(a => a.Oras)
                .FirstOrDefault();
        }


    }
}
