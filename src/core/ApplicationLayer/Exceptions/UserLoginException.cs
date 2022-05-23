namespace ApplicationLayer.Exceptions
{
    public class UserLoginException : Exception
    {
        public UserLoginException()
        { 
        }

        public UserLoginException(string message)
        : base(message)
        {
        }

        public UserLoginException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
