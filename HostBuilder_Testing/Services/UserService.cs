using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

        public async Task<bool> Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (HasUser(user.UserId))
            {
                throw new Exception("User already exist");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentNullException(nameof(user.Username));
            }

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public bool HasUser(Guid UserId)
        {
            return _dataContext.Users.Any(u => u.UserId == UserId);
        }
    }
}
