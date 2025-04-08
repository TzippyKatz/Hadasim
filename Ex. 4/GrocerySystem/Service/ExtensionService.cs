using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Service.Dto;
using Service.Interfaces;
using Service.Services;

namespace Service
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IService<MerchandiseDto>, MerchandiseService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISuppMerchService, SupplierMerchandiseService>();
            services.AddScoped<IService<SupplierDto>, SupplierService>();
            services.AddScoped<IService<UserDto>, UserService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddAutoMapper(typeof(MyMapper));
            return services;
        }
    }
}
