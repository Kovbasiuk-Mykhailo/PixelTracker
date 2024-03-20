using PixelService.Apis;
using PixelService.Configuration;
using PixelService.Extensions;
using ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddBasicServiceDefaults()
    .AddApplicationServices()
    .AddDefaultOpenApi();

var app = builder.Build();

app
    .MapDefaultEndpoints()
    .UseDefaultOpenApi()
    .UseHttpsRedirection();

app.MapGroup("/api/v1/track")
    .WithTags("Tracking API")
    .MapTrackingApi(builder.Configuration.GetSection(TrackingOptions.SectionName).Get<TrackingOptions>()!);

app.Run();