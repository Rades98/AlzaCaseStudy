namespace ApplicationLayer.Dtos
{
    /// <summary>
    /// RestDtoBase to add links to requests and queries (HATEOAS)
    /// </summary>
    public class RestDtoBase
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
