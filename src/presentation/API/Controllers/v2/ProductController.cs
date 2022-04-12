namespace API.Controllers.v2
{
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("2")]
    public class ProductController : BaseController<ProductEntity>
    {
        public ProductController(IMediator mediator) : base(mediator)
        {      
        }
    }
}