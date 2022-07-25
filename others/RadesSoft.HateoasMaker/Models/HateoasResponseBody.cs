namespace RadesSoft.HateoasMaker.Models
{
	public class HateoasResponseBody
	{
		public string Href { get; set; }
		public string Rel { get; set; }
		public string Method { get; private set; }
		internal HateoasResponseBody(string href, string rel, string method)
		{
			Href = href;
			Rel = rel;
			Method = method;
		}

		internal void ReplaceInHref(string oldVal, string newVal)
		{
			Href = Href.Replace(oldVal, newVal);
		}

		internal void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2);
		}

		internal void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2).Replace(oldVal3, newVal3);
		}

		internal void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3, string oldVal4, string newVal4)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2).Replace(oldVal3, newVal3).Replace(oldVal4, newVal4);
		}

		internal void ReplaceInHref(string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3, string oldVal4, string newVal4, string oldVal5, string newVal5)
		{
			Href = Href.Replace(oldVal, newVal).Replace(oldVal2, newVal2).Replace(oldVal3, newVal3).Replace(oldVal4, newVal4).Replace(oldVal5, newVal5);
		}

		internal void ReplaceInHref(Dictionary<string, string> keyValuePairs)
		{
			foreach (KeyValuePair<string, string> pair in keyValuePairs)
			{
				Href = Href.Replace(pair.Key, pair.Value);
			}
		}
	}
}
