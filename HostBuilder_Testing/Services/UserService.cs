using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostBuilder_Testing.Data;
using HostBuilder_Testing.Models;
using HostBuilder_Testing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HostBuilder_Testing.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetByUserId(Guid userId)
        {
            return await _dataContext.Users.FindAsync(userId) ?? new();
        }

        public async Task<IEnumerable<User>> Users()
        {
            return await _dataContext.Users.ToListAsync() ?? new();
        }
    }
}
