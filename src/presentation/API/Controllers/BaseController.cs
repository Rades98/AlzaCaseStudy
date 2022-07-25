namespace API.Controllers
{
	using System.IdentityModel.Tokens.Jwt;
	using System.Linq;
	using System.Security.Claims;
	using DomainLayer.Entities;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Net.Http.Headers;
	using RadesSoft.HateoasMaker;

	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	public abstract class BaseController<T> : Controller where T : AuditableEntity
	{
		private readonly IMediator _mediator;
		private readonly ILogger<T> _logger;
		private readonly HateoasMaker _hateoasMaker;

		public IMediator Mediator => _mediator;
		public HateoasMaker HateoasMaker => _hateoasMaker;
		public ILogger<T> Logger => _logger;

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
