using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using DrozdHW_AQA.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Modules
{
    public static class DataAccessMarketplaceModule
    {
        public static IServiceCollection AddDataAccessMarketplace(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository>(p => new UserRepository(connectionString));
            services.AddScoped<IAddressRepository>(p => new AddressRepository(connectionString));
            services.AddScoped<ICategoryRepository>(p => new CategoryRepository(connectionString));
            services.AddScoped<IProductRepository>(p => new ProductRepository(connectionString));
            services.AddScoped<IOrderRepository>(p => new OrderRepository(connectionString));
            return services;
        }


    }
}
