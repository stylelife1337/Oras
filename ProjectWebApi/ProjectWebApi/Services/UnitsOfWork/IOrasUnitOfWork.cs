using ProjectWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public interface IOrasUnitOfWork
    {
        IOrasRepository Cities { get; }

        ITaraRepository Countries { get; }

        int Complete();

    }
}
