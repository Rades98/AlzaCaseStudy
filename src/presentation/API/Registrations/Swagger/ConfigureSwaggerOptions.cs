namespace API.Registrations.Swagger
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;


    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;


        public void Configure(SwaggerGenOptions options)
        {
            //TODO resolve this somehow
            //foreach (var description in provider.ApiVersionDescriptions)
            //{
            //    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            //}

            options.SwaggerDoc("v1", CreateInfoForApiVersion("v1"));
            options.SwaggerDoc("v2", CreateInfoForApiVersion("v2"));
        }

        private static OpenApiInfo CreateInfoForApiVersion(/*ApiVersionDescription description*/ string version)
        {
            var info = new OpenApiInfo()
            {
                Title = "Alza api",
                Version = /*description.ApiVersion.ToString(),*/ version,
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
                    Url = new Uri("https://alza.cz/license")
                }
            };

            return info;
        }
    }
}
