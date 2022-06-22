namespace API.Registrations.Swagger
{
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", CreateInfoForApiVersion("v1"));
            options.SwaggerDoc("v2", CreateInfoForApiVersion("v2"));
            options.SwaggerDoc("v3", CreateInfoForApiVersion("v3"));
        }

        private static OpenApiInfo CreateInfoForApiVersion(string version)
        {
            var info = new OpenApiInfo()
            {
                Title = "Alza api",
                Version = version,
                TermsOfService = new Uri("https://alza.cz/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Api Guy",
                    Url = new Uri("https://alza.cz/contact"),
                    Email = "apiguy@alza.cz"
                },
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://opensource.org/licenses")
                }
            };

            return info;
        }
    }
}
