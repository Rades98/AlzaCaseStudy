using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController<T> : Controller where T : AuditableEntity
    {
        private IMediator _mediator;
        private IMemoryCache _cacheProvider;
        public IMediator Mediator => _mediator;
        public IMemoryCache CacheProvider => _cacheProvider;

        protected BaseController(IMemoryCache cache, IMediator mediator) => (_cacheProvider, _mediator) = (cache, mediator);
    }
}
