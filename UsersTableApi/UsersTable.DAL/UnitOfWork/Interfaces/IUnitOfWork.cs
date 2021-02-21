using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersTable.DAL.Models;
using UsersTable.DAL.Repositoreis;

namespace UsersTable.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository Users { get; }
        public void Save();
    }
}
