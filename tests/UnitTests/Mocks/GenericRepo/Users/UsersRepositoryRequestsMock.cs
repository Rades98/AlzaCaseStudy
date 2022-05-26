namespace UnitTests.Mocks.GenericRepo.Users
{
    using ApplicationLayer.Services.Users.Commands.Login;
    using System.Text;

    public static class UsersRepositoryRequestsMock
    {
        public static UserLoginRequest UserLoginRequest = new()
        {
            Password = "Password",
            UserName = "usr01",
            Token = Encoding.UTF8.GetBytes("E9B22F7125BFDC355B2149B2A42C28918E862E69BBAFC32FC174ADE6FF")
        };
    }
}
