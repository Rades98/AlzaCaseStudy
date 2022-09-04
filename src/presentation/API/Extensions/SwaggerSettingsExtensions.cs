namespace API.Extensions
{
	public static class SwaggerSettingsExtensions
	{
		public static void ConfigureSwagger(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
					options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
					options.SwaggerEndpoint("/swagger/v3/swagger.json", "v3");
				});
			}
		}
	}
}
