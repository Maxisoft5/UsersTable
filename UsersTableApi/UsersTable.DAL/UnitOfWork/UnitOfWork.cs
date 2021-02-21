using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersTable.DAL.EF;
using UsersTable.DAL.Models;
using UsersTable.DAL.Repositoreis;
using UsersTable.DAL.Repositoreis.Interfaces;
using UsersTable.DAL.UnitOfWork.Interfaces;

namespace UsersTable.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersContext _context;
        private UserRepository _userRepository;
        private bool _disposed = false;

        public UnitOfWork(UsersContext context)
        {
            _context = context;
        }

        public UserRepository Users
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_context); }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() => _context.SaveChanges();
    }
}