namespace API.Registrations.ResponseCompression
{
    using Microsoft.AspNetCore.ResponseCompression;
    using System.IO.Compression;

    public static class ResponseCompressingExtensions
    {
        public static void ConfigureResponseCompression(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(opt =>
            {
                opt.Level = CompressionLevel.Fastest;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });
        }
    }
}
