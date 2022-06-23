namespace DomainLayer.Entities
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
