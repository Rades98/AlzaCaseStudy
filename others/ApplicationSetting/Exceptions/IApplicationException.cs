using CodeLists.Exceptions;

namespace ApplicationSetting.Exceptions
{

	public interface IApplicationException
	{
		public ExceptionType Type { get; set; }
		public string Message { get; }
	}
}
