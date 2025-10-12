using eCommerce.Core.ServiceContract;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extention method to add Core Service to the Dependency injection container
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection service)
        {
            // TO DO : Add services to the IoC Container
            // Core Service often includes data access, caching and other low-level component.
            service.AddTransient<IUsersService, UsersService>();

            return service;
        }
    }
}
