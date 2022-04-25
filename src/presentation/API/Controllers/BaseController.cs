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
        private readonly ILogger<T> _logger;
        private readonly IReadOnlyList<ActionDescriptor> _routes;

        public IMediator Mediator => _mediator;

        protected BaseController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<T> logger) => (_mediator, _routes, _logger) = (mediator, adcp.ActionDescriptors.Items, logger);

        internal LinkDto? UrlLink(string relation, string routeName, object? values = null)
        {
            var route = _routes.FirstOrDefault(f =>
                                    f.AttributeRouteInfo?.Name == routeName);

            if (route is null || route.ActionConstraints is null)
            {
                _logger.LogError($"Did not found action constraint for {routeName}");
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
                _logger.LogError($"Failed when creating url for {routeName}");
                return null;
            }

            return new LinkDto(url, relation, method);
        }
    }
}
