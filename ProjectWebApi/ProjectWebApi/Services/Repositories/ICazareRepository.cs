using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.Repositories
{
    public interface ICazareRepository : IRepository<Cazare>
    {

        Cazare GetCazareDetails(Guid CazareId);

    }
}
