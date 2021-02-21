using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.DAL.Models;

namespace UsersTable.DAL.Repositoreis.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetActiveUsers();
        Task<bool> ActivateUser(int id);
        Task<bool> DisActivateUser(int id);
    }
}