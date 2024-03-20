using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace ServiceDefaults;

public static class WebApplicationExtensions
{
    public static WebApplication UseDefaultOpenApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
    
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        return app;
    }
}