using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.DAL.EF;
using UsersTable.DAL.Models;
using UsersTable.DAL.Repositoreis.Interfaces;
using Microsoft.EntityFrameworkCore;
using UsersTable.DAL.LinqExtensions;

namespace UsersTable.DAL.Repositoreis
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _usersContext;
        public UserRepository(UsersContext context)
        {
            _usersContext = context;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<User> Create(User model)
        {
            await _usersContext.Users.AddAsync(model);
            await _usersContext.SaveChangesAsync();
            return model;
        }

        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var item = GetAsync(id);
            if (item == null)
            {
                return false;
            }
            _usersContext.Users.Remove(await GetAsync(id));
            await _usersContext.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// Get all active users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetActiveUsers()
        {
            return await _usersContext.Users.IsActive().ToListAsync();
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersContext.Users.ToListAsync();
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetAsync(int id)
        {
            return _usersContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(User model)
        {
            if(model == null)
            {
                return false;
            }
            else
            {
                _usersContext.Users.Update(model);
                await _usersContext.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Activate user by id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ActivateUser(int id)
        {
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return false;
            }
            else
            {
                user.IsActive = true;
                await _usersContext.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Disactivate user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DisActivateUser(int id)
        {
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return false;
            }
            else
            {
                user.IsActive = false;
                await _usersContext.SaveChangesAsync();
                return true;
            }
        }

    }
}
