namespace ApplicationLayer.Services.Product.Commands
{
    public class ProductUpdateResponse
    {
        public bool Updated { get; set; } = false;
        public string UpdateMessage { get; set; } = "Product not found";

        internal ProductUpdateResponse() { }
    }
}
