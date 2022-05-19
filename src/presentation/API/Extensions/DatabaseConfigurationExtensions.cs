namespace API.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using PersistenceLayer.Database;

    public static class DatabaseConfigurationExtensions
    {
        public static void MigrateDatabase(this WebApplication app)
        {
            using (var context = app.Services.GetService(typeof(ADbContext)) as ADbContext)
            {
                if (context is not null)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
