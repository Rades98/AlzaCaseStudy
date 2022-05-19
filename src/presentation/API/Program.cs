using API.Extensions;
using API.Registrations;
using Autofac.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Switch to a different DI Container to resolve generic types
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.AddLogger();

builder.Services.AddServices(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseResponseCompression();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.ConfigureEndpoints();
app.ConfigureSwagger();
app.ConfigureExceptionHandlers();
app.MigrateDatabase();

app.Run();
