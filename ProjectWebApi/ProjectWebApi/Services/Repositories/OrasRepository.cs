using ProjectWebApi.Contexts;
using ProjectWebApi.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public class OrasRepository : Repository<Oras>, IOrasRepository
    {
        private readonly AtractieContext _context;

        public OrasRepository(AtractieContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Oras GetOrasDetails(Guid OrasId)
        {
            return _context.Cities
                .Where(o => o.Id == OrasId && (o.Deleted == false || o.Deleted == null))
                .Include(o => o.Tara)
                .FirstOrDefault();
        }

    }
}
