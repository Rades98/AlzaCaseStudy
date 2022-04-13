namespace DomainLayer.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Uri ImgUri { get; set; }
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
