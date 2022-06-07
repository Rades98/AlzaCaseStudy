namespace UnitTests.Mocks.Mediator.ProductDetails
{
    using ApplicationLayer.Services.ProductDetails.Commands;
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using System;

    public static class ProductDetailsMediatorRequestsMock
    {
        #region GET

        public static readonly ProductDetailsGetRequest ProductsGetRequest = new()
        {
            OrderBy = p => p.Name
        };

        public static readonly ProductDetailGetRequest ProductGetRequest = new()
        {
            Id = Guid.NewGuid()
        };

        public static readonly ProductDetailGetRequest ProductGetRequestNotFound = new()
        {
            Id = Guid.NewGuid()
        };

        public static readonly ProductDetailsGetPaginatedRequest ProductsGetPaginatedRequest = new()
        {
            OrderBy = p => p.Name,
            OrderByDesc = false,
            PageNumber = 2,
            PageSize = 4,
        };

        public static readonly ProductDetailsGetRequest ProductsGetRequestWhenNone = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        #endregion

        #region Update

        public static readonly string ProductUpdateDescription = "New cool description";

        public static readonly ProductDetailUpdateRequest ProductUpdateRequest = new()
        {
            Description = ProductUpdateDescription,
            Id = Guid.NewGuid(),
        };

        public static readonly ProductDetailUpdateRequest ProductUpdateRequestNotFound = new()
        {
            Description = ProductUpdateDescription,
            Id = Guid.NewGuid(),
        };

        public static readonly ProductDetailUpdateRequest ProductUpdateRequestUpToDate = new()
        {
            Description = "Smth lol",
            Id = Guid.NewGuid(),
        };

        #endregion
    }
}
