namespace UnitTests.MediatorRequestsTests.ProductDetails.Commands
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductDetails.Commands;
	using Shouldly;
	using Xunit;

	public class ProductDetailUpdateTests : TestsBase
	{
		[Fact]
		public async void ProductDetailUpdateTest_ShouldPass()
		{
			var result = await new ProductDetailUpdateRequest.Handler(DbContext).Handle(new ProductDetailUpdateRequest { Id = 2, Description = "new" }, default);

			result.UpdateMessage.ShouldNotBeNull();
		}

		[Fact]
		public async void ProductDetailUpdateTest_Raise_Error_NotModified()
		{
			try
			{
				var result = await new ProductDetailUpdateRequest.Handler(DbContext).Handle(new ProductDetailUpdateRequest { Id = 1, Description = "description" }, default);
			}
			catch(MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotModified);
			}
		}

		[Fact]
		public async void ProductDetailUpdateTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailUpdateRequest.Handler(DbContext).Handle(new ProductDetailUpdateRequest { Id = 4846456, Description = "description" }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
