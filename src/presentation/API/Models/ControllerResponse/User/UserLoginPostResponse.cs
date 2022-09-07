using ApplicationLayer.Requests.Users.Queries.Login;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.User
{
	public static class UserLoginPostResponse
	{
		public static UserLoginResponse GetResponseModel(this UserLoginResponse model, List<HateoasResponse> links)
		{
			links.First(x => x.ActionName == "self").RequestModel = new Models.User();
			links.FirstOrDefault(x => x.ActionName == "basket")?.ReplaceInLink("{statusId}", $"{CodeLists.OrderStatuses.OrderStatuses.New}");

			if (links is not null)
			{
				model.Links.AddRange(links);
			}

			return model;
		}
	}
}
