using Microsoft.AspNetCore.Diagnostics;

namespace Clinora.Api.Middleware;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (httpContext.Response.HasStarted)
        {
            return false;
        }

        logger.LogError(exception, "Unhandled exception. TraceId: {TraceId}", httpContext.TraceIdentifier);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                success = false,
                error = new
                {
                    code = "INTERNAL_ERROR",
                    message = "An unexpected error occurred.",
                    details = Array.Empty<object>()
                },
                correlationId = httpContext.TraceIdentifier
            },
            cancellationToken);

        return true;
    }
}
