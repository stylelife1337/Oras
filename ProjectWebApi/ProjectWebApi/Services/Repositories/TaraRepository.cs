using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Contexts;
using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public class TaraRepository : Repository<Tara>, ITaraRepository
    {
        private readonly AtractieContext _context;

        public TaraRepository(AtractieContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Tara GetTaraDetails(Guid TaraId)
        {
            return _context.Countries
                .Where(co => co.Id == TaraId && (co.Deleted == false || co.Deleted == null))
                .FirstOrDefault();
        }
    }
}
