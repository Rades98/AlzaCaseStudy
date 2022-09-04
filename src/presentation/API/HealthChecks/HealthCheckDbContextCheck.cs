using Microsoft.Extensions.Diagnostics.HealthChecks;
using PersistanceLayer.Contracts;

namespace API.HealthChecks
{
	public class HealthCheckDbContextCheck : IHealthCheck
	{
		private readonly IDbContext _dbContext;

		public HealthCheckDbContextCheck(IDbContext dbContextProvider) => _dbContext = dbContextProvider;


		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
		{
			try
			{
				if (await _dbContext.Database.CanConnectAsync(cancellationToken))
				{
					return HealthCheckResult.Healthy("Could connect to database");
				}

				return HealthCheckResult.Unhealthy("Could not connect to database");
			}
			catch (Exception e)
			{
				return HealthCheckResult.Unhealthy("Error when trying to check db context", e);
			}
		}
	}
}
