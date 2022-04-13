namespace ApplicationLayer.Services.Product.Commands
{
    public class ProductUpdateResponse
    {
        public bool Updated { get; set; } = false;
        public bool UpToDate { get; set; } = false;
        public string UpdateMessage { get; set; } = CommandMessages.NotFound;

        internal ProductUpdateResponse() { }
    }
}
