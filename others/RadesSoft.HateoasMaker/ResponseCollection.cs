using RadesSoft.HateoasMaker.Models;

namespace RadesSoft.HateoasMaker
{
	internal class ResponseCollection
	{
		internal Dictionary<string, List<LinkCreatorModel>> AvailableLinks { get; set; } = new();

		static readonly Lazy<ResponseCollection> _instanceHolder = new(() => new ResponseCollection());

		internal static readonly ResponseCollection Instance = _instanceHolder.Value;

		ResponseCollection()
		{

		}
	}
}