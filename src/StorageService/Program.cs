using ServiceDefaults;
using StorageService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddBasicServiceDefaults()
    .AddApplicationServices();

var app = builder.Build();

app.MapDefaultEndpoints();

app.Run();