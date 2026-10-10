using Clinora.Api.Middleware;
using Clinora.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSingleton<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler(options =>
{
    options.ExceptionHandler = async httpContext =>
    {
        var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is not null)
        {
            var handler = httpContext.RequestServices.GetRequiredService<GlobalExceptionHandler>();
            await handler.TryHandleAsync(httpContext, exception, httpContext.RequestAborted);
        }
    };
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/api/v1/health")
    .WithName("Health")
    .WithOpenApi();

app.Run();

public partial class Program
{
}
