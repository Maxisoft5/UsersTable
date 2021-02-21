using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersTable.DAL.Repositoreis.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> Create(T model);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T model);
    }
}