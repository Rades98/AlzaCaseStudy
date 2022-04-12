using API.Registrations;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

//Switch to a different DI Container to resolve generic types
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddServices(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpLogging();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.UseEndpoints(builder => builder.MapControllers());
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    //TODO resolve this somehow
    //var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    //foreach (var description in provider.ApiVersionDescriptions)
    //{
    //    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //}

    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
});

app.Run();


