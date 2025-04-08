using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class ExtensionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Merchandise>, MerchandiseRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISuppMerchRepository, SupplierMerchandiseRepository>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            return services;
        }
    }
}
