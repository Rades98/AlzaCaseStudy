namespace API.Controllers.v2
{
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [ApiVersion("2")]
    public class ProductController : BaseController<ProductEntity>
    {
        public ProductController(IMemoryCache cache, IMediator mediator) : base(cache, mediator)
        {
        }
    }
}