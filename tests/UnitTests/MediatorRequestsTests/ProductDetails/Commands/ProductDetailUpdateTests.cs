using System;
using ApplicationLayer.Requests.ProductDetails.Commands;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;


namespace UnitTests.MediatorRequestsTests.ProductDetails.Commands
{
	public class ProductDetailUpdateTests : TestsBase
	{
		[Fact]
		public async void ProductDetailUpdateTest_ShouldPass()
		{
			var result = await new ProductDetailUpdateRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailUpdateRequest { Id = 2, Description = "new" }, default);

			result.UpdateMessage.ShouldNotBeNull();
		}

		[Fact]
		public async void ProductDetailUpdateTest_Raise_Error_NotModified()
		{
			try
			{
				var result = await new ProductDetailUpdateRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailUpdateRequest { Id = 1, Description = "description" }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotModified);
			}
		}

		[Fact]
		public async void ProductDetailUpdateTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailUpdateRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailUpdateRequest { Id = 4846456, Description = "description" }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
