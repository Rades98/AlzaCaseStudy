namespace ApplicationLayer.Exceptions
{
    public class CRUDException : Exception
    {
        public ExceptionTypeEnum Type { get; set; }

        public CRUDException(ExceptionTypeEnum type, string message)
        : base(message)
        {
            Type = type;
        }

        public CRUDException(ExceptionTypeEnum type, string message, Exception inner)
            : base(message, inner)
        {
            Type = type;
        }
    }
}
