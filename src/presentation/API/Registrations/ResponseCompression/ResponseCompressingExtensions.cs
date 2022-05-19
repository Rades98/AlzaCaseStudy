﻿using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace API.Registrations.ResponseCompression
{
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
