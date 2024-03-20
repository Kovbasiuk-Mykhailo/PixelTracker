using Messaging.Core;
using StorageService.Configuration;
using StorageService.Services;

namespace StorageService.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<StorageOptions>(builder.Configuration.GetSection(StorageOptions.SectionName));
        builder.Services.AddScoped<ILogService, FileLogService>();

        builder.Services.ConfigureMassTransit();

        return builder;
    }
}