namespace API.Controllers
{
    using ApplicationLayer.Dtos;
    using DomainLayer.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ActionConstraints;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using System.Linq;

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController<T> : Controller where T : AuditableEntity
    {
        private readonly IMediator _mediator;
        public IMediator Mediator => _mediator;
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        protected BaseController(IMediator mediator, IActionDescriptorCollectionProvider adcp) => (_mediator, _routes) = (mediator, adcp.ActionDescriptors.Items); 
        
        internal LinkDto? UrlLink(string relation, string routeName, object? values = null)
        {
            var route = _routes.FirstOrDefault(f =>
                                    f.AttributeRouteInfo?.Name == routeName);

            if (route is null || route.ActionConstraints is null)
            {
                return null;
            }

            var method = route.
                ActionConstraints
                .OfType<HttpMethodActionConstraint>()
                .First()
                .HttpMethods
                .First();

            var url = Url.Link(routeName, values)?.ToLower();

            if (url is null)
            {
                return null;
            }

            return new LinkDto(url, relation, method);
        }
    }
}
