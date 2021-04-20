using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersTable.DAL.Models;

namespace UsersTable.DAL.LinqExtensions
{
  public static class ListExtensions
  {
    public static IQueryable<User> IsActive(this IQueryable<User> users)
    {
        return users.Where(x => x.IsActive == true);
    }
  }
}
