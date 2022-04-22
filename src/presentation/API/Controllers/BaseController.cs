namespace API.Controllers
{
    using DomainLayer.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController<T> : Controller where T : AuditableEntity
    {
        private readonly IMediator _mediator;
        public IMediator Mediator => _mediator;

        protected BaseController(IMediator mediator) => _mediator = mediator;
    }
}
