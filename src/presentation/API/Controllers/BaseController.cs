using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController<T> : Controller where T : AuditableEntity
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator;

        public BaseController(IMediator mediator) => _mediator = mediator;
    }
}
