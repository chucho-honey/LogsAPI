namespace LogsAPI.Helpers.Constants
{
    public static class SwaggerConst
    {
        public const string ServiceVersion = "v1";

        public const string Bearer = "Bearer";
        public const string DefinitionName = "Authorization";
        public const string BearerFormat = "JWT";

        public const string CustomUi = "custom-swagger-ui";
        public const string VirtualDirectory = "VirtualDirectory";
        public const string SwaggerExtensionXml = ".xml";

        #region log
        public const string SwaggerDocLog = "log";
        public const string LogServiceTitle = "Log API";
        public const string LogServiceName = "log";
        public const string PathLog = "../swagger/log/swagger.json";
        #endregion
    }
}
