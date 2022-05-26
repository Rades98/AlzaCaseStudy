namespace UnitTests.Mocks.GenericRepo.Products
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using System;

    public static class ProductsRepositoryRequestsMock
    {
        #region GET

        public readonly static ProductGetRequest ProductGetRequest = new()
        {
            Id = Guid.NewGuid(),
        };

        public readonly static ProductGetRequest ProductGetRequestNotFound = new()
        {
            Id = Guid.NewGuid(),
        };

        public static readonly ProductsGetPaginatedRequest ProductsGetPaginatedRequest = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
            PageNumber = 1,
            PageSize = 10
        };

        public static readonly ProductsGetRequest ProductsGetRequest = new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        public static readonly ProductsGetRequest ProductsGetRequestWhenNone = new()
        {
            OrderBy = o => o.Id,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        #endregion

        #region Updata

        public static readonly ProductUpdateRequest ProductUpdateRequest = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        public static readonly ProductUpdateRequest ProductUpdateRequestUptoDate = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        public static readonly ProductUpdateRequest ProductUpdateRequestNotFound = new()
        {
            Id = Guid.NewGuid(),
            Description = "Some awesome new description"
        };

        #endregion
    }
}
