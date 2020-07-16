using ProjectWebApi.Entities;
using System.Collections.Generic;

namespace ProjectWebApi.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}