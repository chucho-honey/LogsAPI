using AutoMapper;
using LogsAPI.Helpers;
using LogsAPI.Interfeces;
using LogsAPI.Models;
using LogsAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace LogsAPI.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddInyeccionDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMap();
            services.ConfigureInjection(configuration);
            services.DependencyInjection();

            return services;
        }

        private static IServiceCollection AddAutoMap(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(MC =>
            {
                MC.AddProfile<DtoToDtoAutoMapping>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
            services.AddSingleton<ILogService, LogService>();

            return services;
        }

        private static IServiceCollection ConfigureInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection(nameof(MongoDBSettings)));
            return services;
        }
    }
}
