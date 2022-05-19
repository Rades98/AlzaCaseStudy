namespace ApplicationLayer.Services.Product.Queries
{
    using DomainLayer.Entities.Product;
    using Dtos;
    using Interfaces;

    /// <summary>
    /// Shared response for Get based requests
    /// </summary>
    public class ProductGetResponse : RestDtoBase, IRecord
    {
        public Uri? ImgUri { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public DateTime? Deleted { get; set; }

        public ProductGetResponse() { }

        //Used for retyping from entity to product response dto
        public static explicit operator ProductGetResponse(ProductEntity v)
        {
            return new ProductGetResponse()
            {
                ImgUri = v.ImgUri,
                Name = v.Name,
                Price = v.Price,
                Changed = v.Changed,
                Created = v.Created,
                Deleted = v.Deleted,
                Description = v.Description,
                Id = v.Id,
            };
        }
    }
}
