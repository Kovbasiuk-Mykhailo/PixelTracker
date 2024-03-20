using MassTransit;
using Microsoft.Extensions.Options;
using PixelService.Configuration;

namespace PixelService.Models;

public class TrackingServices(
    HttpContext httpContext,
    IOptions<TrackingOptions> options,
    IPublishEndpoint publishEndpoint,
    ILogger<TrackingServices> logger)
{
    public HttpContext HttpContext { get; } = httpContext;
    public IOptions<TrackingOptions> Options { get; } = options;
    public IPublishEndpoint PublishEndpoint { get; } = publishEndpoint;
    public ILogger<TrackingServices> Logger { get; } = logger;
};