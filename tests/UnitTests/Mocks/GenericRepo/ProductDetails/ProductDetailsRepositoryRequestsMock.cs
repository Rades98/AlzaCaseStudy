namespace UnitTests.Mocks.GenericRepo.ProductDetails
{
    using ApplicationLayer.Services.ProductDetails.Commands;
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using System;

    public static class ProductDetailsRepositoryRequestsMock
    {
        #region GET

        public readonly static ProductDetailGetRequest ProductGetRequest = new()
        {
            Id = Guid.NewGuid(),
        };

        public readonly static ProductDetailGetRequest ProductGetRequestNotFound = new()
        {
            Id = Guid.NewGuid(),
        };

        public static readonly ProductDetailsGetPaginatedRequest ProductsGetPaginatedRequest = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
            PageNumber = 1,
            PageSize = 10
        };

        public static readonly ProductDetailsGetRequest ProductsGetRequest = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        public static readonly ProductDetailsGetRequest ProductsGetRequestWhenNone = new()
        {
            OrderBy = o => o.Id,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        #endregion

        #region Updata

        public static readonly ProductDetailUpdateRequest ProductUpdateRequest = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        public static readonly ProductDetailUpdateRequest ProductUpdateRequestUptoDate = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        public static readonly ProductDetailUpdateRequest ProductUpdateRequestNotFound = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        #endregion
    }
}
