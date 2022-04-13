namespace ApplicationLayer.Services.Product.Commands
{
    /// <summary>
    /// Response for <see cref="ProductUpdateRequest"/>
    /// </summary>
    public class ProductUpdateResponse
    {
        public bool Updated { get; set; } = false;
        public bool UpToDate { get; set; } = false;
        public string UpdateMessage { get; set; } = CommandMessages.NotFound;

        internal ProductUpdateResponse() { }
    }
}
