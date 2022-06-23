namespace PersistanceLayerDapper.Extensions
{
	using System.Data;
	using Dapper;

	public static class ProcedureExecutor
	{
		public static async Task<List<T>> ExecuteProcedureAsync<T>(this DapperContext context, string procedureName, object parameters)
		{
			using var conn = context.CreateConnection();
			return (await conn.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure)).ToList();
		}

		public static async Task<List<object>> ExecuteProcedureAsync(this DapperContext context, string procedureName, object parameters)
		{
			using var conn = context.CreateConnection();
			return (await conn.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure)).ToList();
		}
	}
}
