using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        ///  Extension method to add infrastructure service to the dependency injection 
        ///  container
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            // TO DO : Add services to the IoC Container 
            // Infrastrucutre service often includes data access, caching and other low-level component.
            
            service.AddSingleton<IUserRepository, UsersRepository>();
            
            return service;
        }
    }
}
