using API.Registrations;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Switch to a different DI Container to resolve generic types
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.AddLogger();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(builder =>
{
    builder.MapControllers();
    builder.MapHealthChecks("/hc", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    });
}

app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

app.Run();
