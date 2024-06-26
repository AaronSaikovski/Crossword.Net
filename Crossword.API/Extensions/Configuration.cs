using Crossword.API.Middleware;

namespace Crossword.API.Extensions;

//Source: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/

/// <summary>
/// RegisterServices
/// </summary>
public static class Configuration
{
    #region RegisterServices
    /// <summary>
    /// RegisterServices
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
    #endregion

    #region RegisterMiddleware
    /// <summary>
    /// RegisterMiddleware
    /// </summary>
    /// <param name="app"></param>
    public static void RegisterMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
                .UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<ApiKeyMiddleware>();
    }
    #endregion
}