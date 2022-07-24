namespace RadesSoft.HateoasMaker.Attributes
{
	using System.Runtime.CompilerServices;
	using Models;
	using RadesSoft.HateoasMaker;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class HateoasResponseAttribute : Attribute
	{
		public HateoasResponseAttribute(string relation, string routeName, int version, string values = "", [CallerMemberName] string caller = "")
		{
			List<LinkCreatorModel>? value;
			if (ResponseCollection.Instance.AvailableLinks.TryGetValue(caller, out value))
			{
				if (!value.Any(x => x.RouteName == routeName && x.Version == version))
				{
					value.Add(new() { Relation = relation, RouteName = routeName, Values = values, Version = version });
				}
			}
			else
			{
				ResponseCollection.Instance.AvailableLinks.Add(caller, new() { new() { Relation = relation, RouteName = routeName, Values = values, Version = version } });
			}
		}
	}
}
