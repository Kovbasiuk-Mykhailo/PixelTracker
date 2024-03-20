using Messaging.Contract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Primitives;
using PixelService.Configuration;
using PixelService.Models;

namespace PixelService.Apis;

public static class TrackingApi
{
    public static IEndpointRouteBuilder MapTrackingApi(
        this IEndpointRouteBuilder app,
        TrackingOptions trackingOptions)
    {
        app.MapGet("/", Track)
            .Produces<FileContentHttpResult>(contentType: trackingOptions.ImageType);

        return app;
    }

    private static async Task<FileContentHttpResult> Track([AsParameters] TrackingServices services)
    {
        var referer = services.HttpContext.Request.Headers.Referer;
        var userAgent = services.HttpContext.Request.Headers.UserAgent;
        var ipAddress = services.HttpContext.Connection.RemoteIpAddress?.ToString();

        var options = services.Options.Value;

        var image = await ReadImageFromFile(services, options);

        await PublishPageVisitedEvent(services, referer, userAgent, ipAddress);

        return TypedResults.File(image, options.ImageType);
    }

    private static async Task PublishPageVisitedEvent(
        TrackingServices services,
        StringValues referer,
        StringValues userAgent,
        string? ipAddress)
    {
        var @event = new PageVisitedEvent(referer, userAgent, ipAddress, DateTime.UtcNow);
        try
        {
            await services.PublishEndpoint.Publish(@event);
        }
        catch (Exception ex)
        {
            services.Logger.LogError(ex, $"Failed publishing {nameof(PageVisitedEvent)} with Id {@event.Id}.");
            throw;
        }
    }

    private static async Task<byte[]> ReadImageFromFile(TrackingServices services, TrackingOptions options)
    {
        byte[] image;
        try
        {
            image = await File.ReadAllBytesAsync(options.ImagePath);
        }
        catch (Exception ex)
        {
            services.Logger.LogError(ex, $"Failed reading image {options.ImagePath}");
            throw;
        }

        return image;
    }
}