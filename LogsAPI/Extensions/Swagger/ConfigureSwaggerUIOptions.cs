using LogsAPI.Helpers.Constants;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace LogsAPI.Extensions.Swagger
{
    public static class ConfigureSwaggerUIOptions
    {
        public static SwaggerUIOptions AddSwaggerEndpointsPath(this SwaggerUIOptions c)
        {
            c.SwaggerEndpoint(SwaggerConst.PathLog, SwaggerConst.LogServiceTitle);
            return c;
        }
    }
}
