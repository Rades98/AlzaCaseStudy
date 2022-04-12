using API.Registrations;
using ApplicationLayer.Services.Product.Queries;
using ApplicationLayer.Services.Product.Queries.Requests;
using Autofac.Extensions.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

//Switch to a different DI Container to resolve generic types
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddLogging();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


