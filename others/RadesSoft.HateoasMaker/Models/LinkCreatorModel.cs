namespace RadesSoft.HateoasMaker.Models
{
	internal class LinkCreatorModel
	{
		public string Relation { get; set; } = string.Empty;
		public string RouteName { get; set; } = string.Empty;
		public int Version { get; set; }
		public string Values { get; set; } = string.Empty;
	}
}
