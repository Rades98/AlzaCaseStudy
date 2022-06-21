namespace PersistanceLayerDapper.Extensions
{
	using System.Data;
	using Dapper;

	public static class ProcedureExecutor
	{
		public static async Task<object> ExecuteProcedureAsync(this DapperContext context, string procedureName, object parameters)
		{
			using var conn = context.CreateConnection();
			return (await conn.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure)).ToList();
		}
	}
}
