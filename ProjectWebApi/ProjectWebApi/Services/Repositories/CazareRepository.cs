using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Contexts;
using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public class CazareRepository : Repository<Cazare>, ICazareRepository
    {
        private readonly AtractieContext _context;

        public CazareRepository(AtractieContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Cazare GetCazareDetails(Guid CazareId)
        {
            return _context.Bookings
                .Where(c => c.Id == CazareId && (c.Deleted == false || c.Deleted == null))
                .FirstOrDefault();
        }

    }
}
