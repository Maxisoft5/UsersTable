using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersTable.DAL.UnitOfWork.Interfaces;
using UsersTable.BLL.Services.Interfaces;
using UsersTable.DAL.Models;
using System.Threading.Tasks;
using UsersTable.BLL.ModelsDTO;

namespace UsersTable.BLL.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _dataBase;
        public UserServices(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
        
        public Task<IEnumerable<User>> GetUsers()
        {
            return _dataBase.Users.GetAllAsync();
        }

        public async Task<User> GetAsync(int id) => await _dataBase.Users.GetAsync(id);

        public async Task<User> CreateUserAsync(UserDTO model)
        {
            var user = new User() { Id = model.Id, PublicId = model.PublicId, IsActive = model.IsActive, Name = model.Name };
            return await _dataBase.Users.Create(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _dataBase.Users.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(UserDTO model)
        {
            var user = new User() { Id = model.Id, PublicId = model.PublicId, IsActive = model.IsActive, Name = model.Name };
            return await _dataBase.Users.UpdateAsync(user);
        }

        public Task<int> GetActiveUsersCount()
        {
            return _dataBase.Users.GetActiveUsersCount();
        }

        public Task<bool> ActivateUser(int id)
        {
            return _dataBase.Users.ActivateUser(id);
        }

        public Task<bool> DisActivateUser(int id)
        {
            return _dataBase.Users.DisActivateUser(id);
        }

    }
}
