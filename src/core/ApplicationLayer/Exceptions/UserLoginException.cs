namespace ApplicationLayer.Exceptions
{
    public class UserLoginException : Exception
    {
        public static readonly string UsrNotFound = "User not found";
        public static readonly string WrongPw = "Wrong PW";

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
