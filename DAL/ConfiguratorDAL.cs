using EmployeeCS.DAL;
using EmployeeCS.DAL.Repos.Impls;
using EmployeeCS.DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ConfiguratorDAL
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeCS")));

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
