using System.Data;
using Dapper;

namespace PersistanceLayerDapper.Extensions
{
	public static class TranslationProvider
	{
		public static async Task<string> GetTranslation(this DapperContext context, string textCode, string languageCode, string defaultValue)
		{
			using var conn = context.CreateConnection();
			return await conn.QueryFirstAsync("[dbo].[GetMessageTranslation]", new { @LanguageCode = languageCode, @MessageCode = textCode }, commandType: CommandType.StoredProcedure);
		}
}
}
