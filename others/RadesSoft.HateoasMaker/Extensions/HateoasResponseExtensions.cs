using RadesSoft.HateoasMaker.Models;

namespace RadesSoft.HateoasMaker.Extensions
{
	public static class HateoasResponseExtensions
	{
		public static void ReplaceInLink(this HateoasResponse res, string oldVal, string newVal)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldVal, newVal);
			}
		}

		public static void ReplaceInLink(this HateoasResponse res, string oldVal, string newVal, string oldVal2, string newVal2)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldVal, newVal, oldVal2, newVal2);
			}
		}

		public static void ReplaceInLink(this HateoasResponse res, string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldVal, newVal, oldVal2, newVal2, oldVal3, newVal3);
			}
		}

		public static void ReplaceInLink(this HateoasResponse res, string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3, string oldVal4, string newVal4)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldVal, newVal, oldVal2, newVal2, oldVal3, newVal3, oldVal4, newVal4);
			}
		}

		public static void ReplaceInLink(this HateoasResponse res, string oldVal, string newVal, string oldVal2, string newVal2, string oldVal3, string newVal3, string oldVal4, string newVal4, string oldVal5, string newVal5)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldVal, newVal, oldVal2, newVal2, oldVal3, newVal3, oldVal4, newVal4, oldVal5, newVal5);
			}
		}

		public static void ReplaceInLink(this HateoasResponse res, Dictionary<string, string> oldNewPairs)
		{
			if (res.Curl is not null)
			{
				res.Curl.ReplaceInHref(oldNewPairs);
			}
		}
	}
}
