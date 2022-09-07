using API.Constants;
using API.Controllers.Orders.v1;
using API.Controllers.ProductDetails.v1;
using API.Models;
using API.Models.ControllerResponse.User;
using ApplicationLayer.Requests.Users.Commands.ConfirmRegistration;
using ApplicationLayer.Requests.Users.Commands.Register;
using ApplicationLayer.Requests.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;
using RadesSoft.HateoasMaker.Models;

namespace API.Controllers.Users.v1
{
	/// <summary>
	/// Users endpoint v1
	/// </summary>
	[ApiVersion("1")]
	public class UsersController : BaseController<UsersController>
	{
		private IConfiguration _configuration { get; }

		public UsersController(IMediator mediator, ILogger<UsersController> logger, IConfiguration configuration, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Log in user
		/// </summary>
		/// <param name="user">user to log in</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns token if credentials were correct 
		/// for test purpose use Admin aJc48262_1Kjkz>X!
		/// </remarks>
		[HttpPost(Name = nameof(LoginUserAsync))]
		[MapToApiVersion("1")]
		[MapToApiVersion("2")]
		[MapToApiVersion("3")]
		[HateoasResponse("user_login", nameof(LoginUserAsync), 1)]
		[HateoasResponse("user_login", nameof(LoginUserAsync), 2)]
		[HateoasResponse("user_login", nameof(LoginUserAsync), 3)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UserLoginResponse>> LoginUserAsync(User user, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new UserLoginRequest { Password = user.Password, UserName = user.UserName, Token = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value) }, cancellationToken);

			// when there will be used identity server, cookies should be stored there aswell with token and so on...

			if (result.OrderCode is not null)
			{
				var cookieOptions = new CookieOptions()
				{
					Path = "/",
					Expires = DateTimeOffset.UtcNow.AddDays(1),
					IsEssential = true,
					HttpOnly = true,
					Secure = true,
				};

				Response.Cookies.Append(CookieNames.ActualOrder, result.OrderCode, cookieOptions);
			}

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(OrdersController.GetActiveOrdersAsync), "activeOrders" },
				{ nameof(OrdersController.GetArchiveOrdersAsync), "archiveOrders" },
				{ nameof(OrdersController.GetOrdersFilteredAsync), "basket" },
				//TODO Logout
			};

			return Ok(result.GetResponseModel(HateoasMaker.GetByNames(choices, ApiVersion)));
		}

		/// <summary>
		/// Register in user
		/// </summary>
		/// <param name="user">user to register</param>
		/// <param name="cancellationToken">cancelation token</param>
		[HttpPut(Name = nameof(RegisterUserAsync))]
		[MapToApiVersion("1")]
		[MapToApiVersion("2")]
		[MapToApiVersion("3")]
		[HateoasResponse("user_register", nameof(RegisterUserAsync), 1)]
		[HateoasResponse("user_register", nameof(RegisterUserAsync), 2)]
		[HateoasResponse("user_register", nameof(RegisterUserAsync), 3)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UserLoginResponse>> RegisterUserAsync(UserRegistration user, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new UserRegisterRequest
			{
				Email = user.Email,
				FirstName = user.FirstName,
				Password = user.Password,
				Surname = user.Surname,
				UserName = user.UserName,
			}, cancellationToken);

			return Ok(result);
		}

		/// <summary>
		/// Verify registration in user
		/// </summary>
		/// <param name="code">user registration verification code</param>
		/// <param name="cancellationToken">cancelation token</param>
		[HttpPatch(Name = nameof(VerifyUserRegistrationAsync))]
		[MapToApiVersion("1")]
		[MapToApiVersion("2")]
		[MapToApiVersion("3")]
		[HateoasResponse("user_register", nameof(VerifyUserRegistrationAsync), 1)]
		[HateoasResponse("user_register", nameof(VerifyUserRegistrationAsync), 2)]
		[HateoasResponse("user_register", nameof(VerifyUserRegistrationAsync), 3)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UserLoginResponse>> VerifyUserRegistrationAsync(string code, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new UserConfirmRegistrationRequest
			{
				Code = code
			}, cancellationToken);

			return Ok(result);
		}
	}
}


