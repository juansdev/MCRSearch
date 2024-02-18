namespace MCRSearch.src.MCRSearch.Infrastructure.Middlewares;
public static class LoggingResponseHttpMiddlewareException
{
    public static IApplicationBuilder UseLoggingResponseHttp(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggingResponseHttpMiddleware>();
    }
}
public class LoggingResponseHttpMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingResponseHttpMiddleware> _logger;

    public LoggingResponseHttpMiddleware(RequestDelegate next, ILogger<LoggingResponseHttpMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Registra el cuerpo de la respuesta en el Logging.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        using (var ms = new MemoryStream())
        {
            var responseOriginalBody = context.Response.Body;
            context.Response.Body = ms;

            await _next(context);
            ms.Seek(0, SeekOrigin.Begin);
            string response = new StreamReader(ms).ReadToEnd();
            ms.Seek(0, SeekOrigin.Begin);
            await ms.CopyToAsync(responseOriginalBody);
            context.Response.Body = responseOriginalBody;

            _logger.LogInformation($"Respuesta de la API: {response}");
        }
    }
}