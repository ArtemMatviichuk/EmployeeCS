using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using EmployeeCS.BLL.Interfaces;
using EmployeeCS.BLL.Impls;

namespace BLL
{
    public static class ConfiguratorBLL
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfiguratorDAL.Configure(services, configuration);

            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
