using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RadesSoft.HateoasMaker;

namespace API.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	public abstract class BaseController<T> : Controller where T : class
	{
		private readonly IMediator _mediator;
		private readonly ILogger<T> _logger;
		private readonly HateoasMaker _hateoasMaker;

		public IMediator Mediator => _mediator;
		public HateoasMaker HateoasMaker => _hateoasMaker;
		public ILogger<T> Logger => _logger;
		public int ApiVersion => Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1;

		protected BaseController(IMediator mediator, ILogger<T> logger, HateoasMaker hateoasMaker) => (_mediator, _logger, _hateoasMaker) = (mediator, logger, hateoasMaker);

		internal int GetUserIdFromToken()
		{
			var accessToken = Request.Headers[HeaderNames.Authorization];
			var token = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.ToString().Replace("Bearer ", ""));
			return Int32.Parse(token.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
		}

		protected string? GetCookieValue(string name)
		{
			string? value;
			Request.Cookies.TryGetValue(name, out value);
			return value;
		}
	}
}
