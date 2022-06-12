namespace UnitTests.Tests.Mediator.Users
{
    using ApplicationLayer.Exceptions.User;
    using ApplicationLayer.Services.Users.Commands.Login;
    using Mocks;
    using Mocks.GenericRepo.Users;
    using Shouldly;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using Xunit;

    public class UserLoginRequestTests
    {
        [Fact]
        public async void Test()
        {

            //Arrange
            var handler = new UserLoginRequest.Handler(
                MockProvider<UserLoginRequest>.UserRepository,
                MockProvider<UserLoginRequest>.UserRoleRepository,
                MockProvider<UserLoginRequest>.UserRoleRelationRepository);

            //Act
            var result = await handler.Handle(UsersRepositoryRequestsMock.UserLoginRequest, CancellationToken.None);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(result.Token);
            var roles = token.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            //Assert
            result.UserName.ShouldBe(UsersRepositoryRequestsMock.UserLoginRequest.UserName);

            roles.ShouldBe(result.Roles);
        }

        [Fact]
        public async void UserNotFoundTest()
        {
            //Arrange
            var handler = new UserLoginRequest.Handler(
                MockProvider<UserLoginRequest>.UserRepository_NoUsr,
                MockProvider<UserLoginRequest>.UserRoleRepository,
                MockProvider<UserLoginRequest>.UserRoleRelationRepository);

            try
            {
                //Act
                var result = await handler.Handle(new UserLoginRequest() { UserName = "sdafusadfhasjkdfafsadfsa" }, CancellationToken.None);
            }
            catch (UserLoginException ex)
            {
                //Assert
                ex.Message.ShouldBe(UserLoginException.UsrNotFound);
            }
        }

        [Fact]
        public async void WrongPasswordTest()
        {
            //Arrange
            var handler = new UserLoginRequest.Handler(
                MockProvider<UserLoginRequest>.UserRepository,
                MockProvider<UserLoginRequest>.UserRoleRepository,
                MockProvider<UserLoginRequest>.UserRoleRelationRepository);

            try
            {
                //Act
                var result = await handler.Handle(new UserLoginRequest()
                {
                    UserName = UsersRepositoryRequestsMock.UserLoginRequest.UserName,
                    Password = "asdasdadadasd",
                    Token = UsersRepositoryRequestsMock.UserLoginRequest.Token
                }, CancellationToken.None);
            }
            catch (UserLoginException ex)
            {
                //Assert
                ex.Message.ShouldBe(UserLoginException.WrongPw);
            }
        }
    }
}
