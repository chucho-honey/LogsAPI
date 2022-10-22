using LogsAPI.Helpers.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace LogsAPI.Extensions.Swagger
{
    public static class ServiceSwagger
    {
        public static IServiceCollection AddServiceSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConst.SwaggerDocLog, new OpenApiInfo
                {
                    Version = SwaggerConst.ServiceVersion,
                    Title = SwaggerConst.LogServiceTitle
                });
               
                c.CustomSchemaIds(x => x.Name.Replace("Dto", string.Empty));

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{SwaggerConst.SwaggerExtensionXml}";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



            return services;
        }
    }
}
