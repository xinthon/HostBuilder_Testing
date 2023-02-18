using HostBuilder_Testing.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostBuilder_Testing.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Users();
        Task<User> GetByUserId(Guid id);
    }
}
