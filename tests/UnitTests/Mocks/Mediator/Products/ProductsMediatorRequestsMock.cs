namespace UnitTests.Mocks.Mediator.Products
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using System;

    public static class ProductsMediatorRequestsMock
    {
        #region GET

        public static readonly ProductsGetRequest ProductsGetRequest = new()
        {
            OrderBy = p => p.Name
        };

        public static readonly ProductGetRequest ProductGetRequest = new()
        {
            Id = Guid.NewGuid()
        };

        public static readonly ProductGetRequest ProductGetRequestNotFound = new()
        {
            Id = Guid.NewGuid()
        };

        public static readonly ProductsGetPaginatedRequest ProductsGetPaginatedRequest = new()
        {
            OrderBy = p => p.Name,
            OrderByDesc = false,
            PageNumber = 2,
            PageSize = 4,
        };

        public static readonly ProductsGetRequest ProductsGetRequestWhenNone = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        #endregion

        #region Update

        public static readonly string ProductUpdateDescription = "New cool description";

        public static readonly ProductUpdateRequest ProductUpdateRequest = new()
        {
            Description = ProductUpdateDescription,
            Id = Guid.NewGuid(),
        };

        public static readonly ProductUpdateRequest ProductUpdateRequestNotFound = new()
        {
            Description = ProductUpdateDescription,
            Id = Guid.NewGuid(),
        };

        public static readonly ProductUpdateRequest ProductUpdateRequestUpToDate = new()
        {
            Description = "Smth lol",
            Id = Guid.NewGuid(),
        };

        #endregion
    }
}
