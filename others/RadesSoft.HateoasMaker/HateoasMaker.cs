using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using RadesSoft.HateoasMaker.Models;

namespace RadesSoft.HateoasMaker
{
	public class HateoasMaker
	{
		private readonly IReadOnlyList<ActionDescriptor> _routes;
		private readonly IUrlHelper _urlHelper;
		private readonly ClaimsPrincipal _user;

		public HateoasMaker(IActionDescriptorCollectionProvider adcp, IUrlHelper urlHelper, ClaimsPrincipal user) => (_routes, _urlHelper, _user) = (adcp.ActionDescriptors.Items, urlHelper, user);

		private HateoasResponseBody? UrlLink(string relation, string routeName, int apiVersion, object? values = null)
		{
			var route = _routes.FirstOrDefault(f =>
				f.AttributeRouteInfo?.Name == routeName && (
					f.EndpointMetadata.OfType<ApiVersionAttribute>().Any() &&
					f.EndpointMetadata.OfType<ApiVersionAttribute>().First().Versions[0].MajorVersion == apiVersion ||
					f.EndpointMetadata.OfType<MapToApiVersionAttribute>().Any(x => x.Versions.Any(ver => ver.MajorVersion == apiVersion))
				));

			if (route is null || route?.ActionConstraints is null)
			{
				return null;
			}

			var method = ((route as ControllerActionDescriptor)!
				.MethodInfo
				.GetCustomAttributes(typeof(HttpMethodAttribute), false)
				.FirstOrDefault() as HttpMethodAttribute)?.HttpMethods.First() ?? "";

			var roles = ((route as ControllerActionDescriptor)!
				.MethodInfo
				.GetCustomAttributes(typeof(AuthorizeAttribute), false)
				.FirstOrDefault() as AuthorizeAttribute)?.Roles ?? "";

			if (!string.IsNullOrEmpty(roles) && !_user.IsInRole(roles))
			{
				return null;
			}

			var url = _urlHelper.Link(routeName, null)?.ToLower();

			url += values;

			if (url is null)
			{
				return null;
			}

			return new HateoasResponseBody(new Uri(url).ToString(), relation, method);
		}

		public List<HateoasResponse> GetByNames(Dictionary<string, string?> endpoints, int version, [CallerMemberName] string selfName = "")
		{
			var response = new List<HateoasResponse>();

			var all = GetAllEndpointLinks(version);
			var self = all
				.First(x => x.Value is not null && x.Key == selfName)!;

			self.Value!.Rel = "_self";

			response.Add(new() { ActionName = "self", Curl = self.Value });

			var rest = all
			.Where(x => x.Value is not null && endpoints.ContainsKey(x.Key));

			foreach (var endpoint in endpoints)
			{
				var toAdd = rest
				.FirstOrDefault(x => x.Value is not null && x.Key == endpoint.Key);

				response.Add(new() { ActionName = endpoint.Value ?? toAdd.Key, Curl = toAdd.Value });
			}

			return response;
		}

		private Dictionary<string, HateoasResponseBody?> GetAllEndpointLinks(int version)
		{
			var result = new Dictionary<string, HateoasResponseBody?>();
			foreach (var response in ResponseCollection.Instance.AvailableLinks)
			{
				var toAdd = response.Value.FirstOrDefault(x => x.Version == version);

				if (toAdd is not null)
				{
					result.Add(response.Key, UrlLink(toAdd.Relation, toAdd.RouteName, toAdd.Version, toAdd.Values));
				}
			}

			return result;
		}
	}
}
