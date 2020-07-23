using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public interface ITaraRepository : IRepository<Tara>
    {

        Tara GetTaraDetails(Guid TaraId);

    }
}
