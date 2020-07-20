using ProjectWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public interface IAtractieUnitOfWork : IDisposable
    {
        IAtractieRepository Attractions  { get; }

        IOrasRepository Cities { get; }


        int Complete();
    }
}
