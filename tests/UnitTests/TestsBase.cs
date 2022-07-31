namespace UnitTests
{
	using System.Security.Claims;
	using ApplicationLayer.Interfaces;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using Moq;
	using RadesSoft.HateoasMaker;

	public class TestsBase
	{
		private readonly ServiceCollectionProvider _services = new();

		private readonly IDbContext _dbContext;
		private readonly IMediator _mediator;
		private readonly ClaimsPrincipal _claims;

		public IDbContext DbContext => _dbContext;
		public IMediator Mediator => _mediator;
		public ClaimsPrincipal Claims => _claims;
		public byte[] Token => _services.Token;

		public TestsBase()
		{
			_dbContext = _services.GetService<IDbContext>();
			_mediator = _services.GetService<IMediator>();
			_claims = new Mock<ClaimsPrincipal>().Object;
		}

		public T GetController<T>() where T : ControllerBase
		{
			return _services.GetService<T>();
		}
	}
}
