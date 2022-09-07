namespace RadesSoft.HateoasMaker.Models
{
	public class HateoasResponseBody
	{
		public string Href { get; set; }
		public string Rel { get; set; }
		public string Method { get; private set; }
		public HateoasResponseBody(string href, string rel, string method)
		{
			Href = href;
			Rel = rel;
			Method = method;
		}

		public void ReplaceInHref(string oldVal, string newVal)
		{
			Href = Href.Replace(oldVal, newVal);
		}

		public void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2);
		}

		public void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2).Replace(oldVal3, newVal3);
		}

		public void ReplaceInHref(Dictionary<string, string> keyValuePairs)
		{
			foreach (KeyValuePair<string, string> pair in keyValuePairs)
			{
				Href = Href.Replace(pair.Key, pair.Value);
			}
		}
	}
}
