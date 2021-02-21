using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.BLL.ModelsDTO;
using UsersTable.DAL.Models;

namespace UsersTable.BLL.Services.Interfaces
{
    public interface IUserServices
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUserAsync(UserDTO user);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UserDTO model);
        Task<IEnumerable<User>> GetActiveUsers();
        Task<bool> ActivateUser(int id);
        Task<bool> DisActivateUser(int id);
        
    }
}
