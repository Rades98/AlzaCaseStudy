using System;
using ApplicationLayer.Requests.ProductCategories.Queries;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.ProductCategories.Queries
{
	public class ProductCategoriesGetByIdTests : TestsBase
	{
		[Fact]
		public async void ProductCategoriesGetById_Shoul_Pass()
		{
			var result = await new ProductCategoriesGetByIdRequest.Handler(ProductCategoriesRepo).Handle(new ProductCategoriesGetByIdRequest() { Id = 1 }, default);

			result.ShouldNotBeNull();
		}

		[Fact]
		public async void ProductCategoriesGetById_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductCategoriesGetByIdRequest.Handler(ProductCategoriesRepo).Handle(new ProductCategoriesGetByIdRequest() { Id = 1000 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
