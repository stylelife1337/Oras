using ProjectWebApi.Services.Repositories;
using System;

namespace ProjectWebApi.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}