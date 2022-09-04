namespace API.Extensions
{
	using Microsoft.EntityFrameworkCore;
	using PersistenceLayer.Database;

	public static class DatabaseConfigurationExtensions
	{
		public static void MigrateDatabase(this WebApplication app, IConfiguration configuration)
		{
			using (var context = app.Services.GetService(typeof(ADbContext)) as ADbContext)
			{
				if (context is not null)
				{
					context.Database.Migrate();

					//This approach is cool.. only till there will not be more procedures.. but for now.. its OK
					if (Convert.ToBoolean(configuration.GetSection("AppSettings:MigrateDbScripts").Value))
					{
						var procedures = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName, "*.sql", SearchOption.AllDirectories);
						procedures.Where(x=> x.Contains("Procedures")).ToList().ForEach(pr => context.Database.ExecuteSqlRaw(File.ReadAllText(pr)));
					}
				}
			}
		}
	}
}
