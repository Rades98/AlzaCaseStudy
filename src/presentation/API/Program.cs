using API.Registrations;
using ApplicationLayer.Services.Product.Queries;
using ApplicationLayer.Services.Product.Queries.Requests;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Switch to a different DI Container to resolve generic types
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//test if mediatr injection works properly
app.MapGet("/", () => TestMediatorFunction(app.Services));

app.Run();





static async Task<ProductGetResponse> TestMediatorFunction(IServiceProvider srv)
{
    var mediator = srv.GetRequiredService<IMediator>();
    var x = await mediator.Send(new ProductGetRequest() { Id = new Guid("076D49AF-6BC0-4DDA-84AB-473C9F72BF60") });
    return x;
}


