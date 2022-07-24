namespace ApplicationLayer.Dtos
{
	using RadesSoft.HateoasMaker.Models;

	/// <summary>
	/// RestDtoBase to add links to requests and queries (HATEOAS)
	/// </summary>
	public class RestDtoBase
	{
		public List<HateoasResponse> Links { get; set; } = new();

	}
}
