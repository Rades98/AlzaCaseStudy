namespace ApplicationSetting.Exceptions
{
	using CodeLists.Exceptions;

	public interface IApplicationException
	{
		public ExceptionType Type { get; set; }
		public string Message { get; }
	}
}
