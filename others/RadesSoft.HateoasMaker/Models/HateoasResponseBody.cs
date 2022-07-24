namespace RadesSoft.HateoasMaker.Models
{
	public class HateoasResponseBody
	{
		public string Href { get; private set; }
		public string Rel { get; set; }
		public string Method { get; private set; }
		internal HateoasResponseBody(string href, string rel, string method)
		{
			Href = href;
			Rel = rel;
			Method = method;
		}
	}
}
