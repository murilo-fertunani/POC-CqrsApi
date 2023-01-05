using System.Reflection;
using AutoMapper;
using CqrsApi.Domain.Handlers;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Infra.Repositories;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            /* Handlers */
            services.AddTransient<IGetProductByIdHandler, GetProductByIdHandler>();
            services.AddTransient<IGetAllProductsHandler, GetAllProductsHandler>();
            services.AddTransient<ICreateProductHandler, CreateProductHandler>();
            services.AddTransient<IUpdateProductHandler, UpdateProductHandler>();
            services.AddTransient<IDisableProductHandler, DisableProductHandler>();
            services.AddTransient<IEnableProductHandler, EnableProductHandler>();

            /* Repositories */
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config => config.AddMaps(Assembly.GetEntryAssembly()));

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }
}