using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public interface IAtractieRepository : IRepository<Atractie>
    {

        Atractie GetAtractieDetails(Guid AtractieId);
    }
}
