using API.Controllers.ProductCategories.v1;
using API.Controllers.ProductDetails.v1;
using API.Controllers.Users.v1;
using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;
using RadesSoft.HateoasMaker.Models;

namespace API.Controllers.Navigation.v1
{
	[ApiVersion("1")]
	public class NavigationController : BaseController<NavigationController>
	{
		public NavigationController(IMediator mediator, ILogger<NavigationController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}

		[HttpGet(Name = nameof(GetNavigation))]
		[HateoasResponse("navigation", nameof(GetNavigation), 1)]
		public List<HateoasResponse>? GetNavigation()
		{
			var choices = new Dictionary<string, string?>()
			{
				{ nameof(UsersController.RegisterUserAsync), "registerUser" },
				{ nameof(UsersController.LoginUserAsync), "loginUser" },
				{ nameof(ProductCategoriesController.GetProductCategopriesAsync), "getCategories" },
				{ nameof(ProductDetailsController.SearchProduct), "searchProduct" },
				{ nameof(ProductDetailsController.GetProductDetailsPaginatedAsync), "loadProductsPagianted" },
				{ nameof(ProductDetailsController.GetProductDetailsAsync), "loadProducts" },
			};

			var links = HateoasMaker.GetByNames(choices, ApiVersion);

			links.First(x => x.ActionName == "registerUser").RequestModel = new UserRegistration();
			links.First(x => x.ActionName == "loginUser").RequestModel = new User();

			return links;
		}
	}
}
