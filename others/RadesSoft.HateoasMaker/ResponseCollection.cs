namespace RadesSoft.HateoasMaker
{
	using Models;

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