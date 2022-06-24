namespace PersistanceLayerDapper
{
	using System.Data;
	using System.Data.SqlClient;
	using Microsoft.Extensions.Configuration;

	public class DapperContext
	{
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ADb");
		}
		public IDbConnection CreateConnection()
			=> new SqlConnection(_connectionString);
	}
}