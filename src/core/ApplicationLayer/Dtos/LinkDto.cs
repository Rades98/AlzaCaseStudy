namespace ApplicationLayer.Dtos
{
	/// <summary>
	/// LinkDto for HATEOAS
	/// </summary>
	public class LinkDto
	{
		public string Href { get; private set; } = string.Empty;
		public string Rel { get; set; } = string.Empty;
		public string Method { get; private set; } = string.Empty;
		public LinkDto(string href, string rel, string method)
		{
			Href = href;
			Rel = rel;
			Method = method;
		}

		public LinkDto()
		{

		}
	}
}
