namespace API.Controllers.Users.v1
{
	using API.Controllers.OrderItems.v1;
	using API.Controllers.Orders.v1;
	using API.Controllers.ProductDetails.v1;
	using API.Models;
	using ApplicationLayer.Requests.Users.Commands.Login;
	using DomainLayer.Entities.Users;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using RadesSoft.HateoasMaker;
	using RadesSoft.HateoasMaker.Attributes;
	using RadesSoft.HateoasMaker.Models;

	/// <summary>
	/// Users endpoint v1
	/// </summary>
	[ApiVersion("1")]
	public class UsersController : BaseController<UserEntity>
	{
		private IConfiguration _configuration { get; }

		public UsersController(IMediator mediator, ILogger<UserEntity> logger, IConfiguration configuration, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
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

			result.Links = HateoasMaker.GetByNames(
				new Dictionary<string, string?>
				{
					{ nameof(OrdersController.GetOrdersAsync), "onMyOrdersClick" },
					{ nameof(OrdersController.GetOrdersFilteredAsync), "onCartClick" },
					{ nameof(ProductDetailsController.GetProductDetailsPaginatedAsync), "loadProductCards" },
					{ nameof(ProductDetailsController.GetProductDetailByIdAsync), "onProductClick" },
					{ nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart" },
				}, Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1);

			return Ok(result);
		}
	}
}


