namespace DomainLayer.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
        public Uri ImgUri { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
