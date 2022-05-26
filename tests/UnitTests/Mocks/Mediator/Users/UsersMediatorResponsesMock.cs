namespace UnitTests.Mocks.Mediator.Users
{
    using ApplicationLayer.Services.Users.Commands.Login;
    using ApplicationLayer.Utils.PasswordHashing;
    using System.Collections.Generic;

    public class UsersMediatorResponsesMock
    {
        private static List<string> _roles => new() { UserRolesCodeList.UserRoles.Admin };

        public static readonly UserLoginResponse UserLoginResponse = new()
        {
            UserName = UsersMediatorRequestsMock.UserLoginRequest.UserName,
            Token = PasswordHashing.CreateToken(UsersMediatorRequestsMock.UserLoginRequest.UserName, UsersMediatorRequestsMock.UserLoginRequest.Token, _roles),
            Roles = _roles
        };
    }
}
