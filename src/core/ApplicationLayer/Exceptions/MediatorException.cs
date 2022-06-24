using System.Runtime.Serialization;

namespace ApplicationLayer.Exceptions
{
    public class MediatorException : Exception, ISerializable
    {
        public ExceptionType Type { get; set; }

        public MediatorException(ExceptionType type, string message)
        : base(message)
        {
            Type = type;
        }

        public MediatorException(ExceptionType type, string message, Exception inner)
            : base(message, inner)
        {
            Type = type;
        }
    }
}
