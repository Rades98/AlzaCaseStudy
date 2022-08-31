namespace PersistenceLayer.Exceptions
{
    using ApplicationSetting.Exceptions;
    using CodeLists.Exceptions;

    public class PersistanceLayerException : Exception, IApplicationException
	{
        public ExceptionType Type { get; set; }
		string IApplicationException.Message { get => base.Message; }

		public PersistanceLayerException(ExceptionType type, string message)
        : base(message)
        {
            Type = type;
        }

        public PersistanceLayerException(ExceptionType type, string message, Exception? inner)
            : base(message, inner)
        {
            Type = type;
        }
    }
}
