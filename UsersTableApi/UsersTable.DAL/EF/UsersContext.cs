using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UsersTable.DAL.Models;

namespace UsersTable.DAL.EF
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User[] {
                 new User { Id = 1, Name = "Andrew", IsActive = false, PublicId = Guid.NewGuid() },
                 new User { Id = 2, Name = "Bob", IsActive = true, PublicId = Guid.NewGuid() },
                 new User { Id = 3, Name = "Alice", IsActive = true, PublicId = Guid.NewGuid() },
                 new User { Id = 4, Name = "Donald", IsActive = false, PublicId = Guid.NewGuid() }
                 });

            base.OnModelCreating(modelBuilder);
        }

    }
}
