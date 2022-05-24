namespace API.Controllers.Users
{
    using API.Models;
    using ApplicationLayer.Services.Users.Commands.Login;
    using DomainLayer.Entities.Users;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// Users endpoint v1
    /// </summary>
    [ApiVersion("1")]
    public class UsersController : BaseController<UserEntity>
    {
        private IConfiguration _configuration { get; }

        public UsersController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<UserEntity> logger, IConfiguration configuration) : base(mediator, adcp, logger)
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
        /// </remarks>
        [HttpPost(Name = nameof(LoginUserAsync))]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync(User user, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new UserLoginRequest { Password = user.Password, UserName = user.UserName, Token = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value) }, cancellationToken);

            return Ok(RestfullProductGetResponse(result));
        }

        private UserLoginResponse RestfullProductGetResponse(UserLoginResponse response)
        {
            var self = UrlLink("_self", nameof(LoginUserAsync), new { user = new User() { UserName = "usrName", Password = "password" } });

            if (self is not null)
            {
                response.Links.Add(self);
            }

            return response;
        }
    }
}


