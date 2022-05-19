namespace API.Extensions
{
    using global::HealthChecks.UI.Client;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;

    public static class EndpointSettingsExtension
    {
        public static void ConfigureEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
                builder.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseHealthChecksUI(config =>
            {
                config.UIPath = "/hc-ui";
            });
        }
    }
}
