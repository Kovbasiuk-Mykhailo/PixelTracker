using Messaging.Core;
using PixelService.Configuration;

namespace PixelService.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.ConfigureMassTransit();
        
        builder.Services.Configure<TrackingOptions>(builder.Configuration.GetSection(TrackingOptions.SectionName));

        return builder;
    }
}