using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using UsersTable.BLL.Services;
using UsersTable.BLL.Services.Interfaces;
using UsersTable.DAL.UnitOfWork;
using UsersTable.DAL.UnitOfWork.Interfaces;

namespace UsersTable.Helpers
{
    public class DependcyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserServices, UserServices>();
        }
    }
}
