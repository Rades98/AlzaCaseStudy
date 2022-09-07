using System;
using ApplicationLayer.Exceptions;
using ApplicationLayer.Requests.Users.Queries.Login;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.Users.Queries
{
	public class UserLoginTests : TestsBase
	{
		[Fact]
		public async void UserLoginTest_Should_Pass()
		{
			var result = await new UserLoginRequest.Handler(UsersRepo, Claims, OrdersRepo).Handle(new UserLoginRequest { Password = "aJc48262_1Kjkz>X!", UserName = "Admin", Token = Token }, default);

			result.UserName.ShouldBe("Admin");
		}

		[Fact]
		public async void UserLoginTest_Raise_Error_NotFound()
		{
			try
			{
				await new UserLoginRequest.Handler(UsersRepo, Claims, OrdersRepo).Handle(new UserLoginRequest { Password = "aJc48262_1Kjkz>X!", UserName = "GuluGulu", Token = Token }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		[Fact]
		public async void UserLoginTest_Raise_Error_UnAuthorized()
		{
			try
			{
				await new UserLoginRequest.Handler(UsersRepo, Claims, OrdersRepo).Handle(new UserLoginRequest { Password = "qwqqwewqerwqrwr", UserName = "Admin", Token = Token }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}
	}
}
