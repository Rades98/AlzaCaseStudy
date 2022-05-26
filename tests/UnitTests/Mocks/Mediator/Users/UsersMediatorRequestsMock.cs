using ApplicationLayer.Services.Users.Commands.Login;

namespace UnitTests.Mocks.Mediator.Users
{
    public class UsersMediatorRequestsMock
    {
        public const string APP_TOKEN = "E9B22F7125BFDC355B2149B2A42C28918E862E69BBAFC32FC174ADE6FF";
        public static readonly UserLoginRequest UserLoginRequest = new()
        {
            Password = "superstrongpw",
            UserName = "usr01",
            Token = System.Text.Encoding.UTF8.GetBytes(APP_TOKEN)
        };
    }
}
