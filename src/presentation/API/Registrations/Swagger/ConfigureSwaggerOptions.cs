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
            options.SwaggerDoc("v1", CreateInfoForApiVersion("v1", "Endpoints using EF Core"));
            options.SwaggerDoc("v2", CreateInfoForApiVersion("v2", "Endpoints using Dapper and stored procedures"));
            options.SwaggerDoc("v3", CreateInfoForApiVersion("v3", "Requests with pagination"));
            options.SwaggerDoc("v4", CreateInfoForApiVersion("v4", "Localized Dapper requests"));
        }

        private static OpenApiInfo CreateInfoForApiVersion(string version, string description = "")
        {
            var info = new OpenApiInfo()
            {
                Title = "API Case study",
                Version = version,
                TermsOfService = new Uri("https://github.com/Rades98/AlzaCaseStudy/wiki"),
                Contact = new OpenApiContact
                {
                    Name = "Radek Řezníček",
                    Url = new Uri(@"https://www.linkedin.com/in/radek-řezníček-545638163/"),
                    Email = "rades9898@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://opensource.org/licenses")
                },
                Description = description,
            };

            return info;
        }
    }
}
