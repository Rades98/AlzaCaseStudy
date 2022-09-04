using API.Middleware;

namespace API.Extensions
{
	public static class ExceptionHandlingExtensions
	{
		public static void ConfigureExceptionHandlers(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseMiddleware<ExceptionMiddleware>();
			}
		}
	}
}
