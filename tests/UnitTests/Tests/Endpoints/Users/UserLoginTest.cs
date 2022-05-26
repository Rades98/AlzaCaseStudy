namespace UnitTests.Tests.Endpoints.Users
{
    using API.Controllers.Users;
    using API.Models;
    using DomainLayer.Entities.Users;
    using Microsoft.AspNetCore.Mvc;
    using Mocks;
    using Mocks.Mediator.Users;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class UserLoginTest
    {
        [Fact]
        public async void LoginTest()
        {
            //Arrange
            var controller = new UsersController(MockProvider<UserEntity>.Mediator, MockProvider<UserEntity>.ADCP, MockProvider<UserEntity>.Logger, MockProvider<UserEntity>.Configuration);

            //Act
            var user = new User()
            {
                UserName = UsersMediatorRequestsMock.UserLoginRequest.UserName,
                Password = UsersMediatorRequestsMock.UserLoginRequest.Password
            };

            var actionResult = await controller.LoginUserAsync(user, CancellationToken.None);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(UsersMediatorResponsesMock.UserLoginResponse);
        }
    }
}
