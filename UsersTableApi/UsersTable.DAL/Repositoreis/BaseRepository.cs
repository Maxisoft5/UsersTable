using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.DAL.EF;
using UsersTable.DAL.Models.Abstract;
using UsersTable.DAL.Repositoreis.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UsersTable.DAL.Repositoreis
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly UsersContext _usersContext;

        public BaseRepository(UsersContext context)
        {
            _usersContext = context;
        }

        /// <summary>
        /// Create a new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<T> Create(T item)
        {
            await _usersContext.Set<T>().AddAsync(item);
            await _usersContext.SaveChangesAsync();
            return item;
        }

        /// <summary>
        /// Delete item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item == null)
            {
                return false;
            }
            else
            {
                _usersContext.Set<T>().Remove(await GetAsync(id));
                await _usersContext.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Get item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int id) => await _usersContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await _usersContext.Set<T>().ToListAsync();

        /// <summary>
        /// Update model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T model)
        {
            if (model == null)
            {
                return false;
            }
            _usersContext.Set<T>().Update(model);
            await _usersContext.SaveChangesAsync();
            return true;
        }

    }
}
