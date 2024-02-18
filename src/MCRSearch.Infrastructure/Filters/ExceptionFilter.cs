using Microsoft.AspNetCore.Mvc.Filters;

namespace MCRSearch.src.MCRSearch.Infrastructure.Filters;

public class ExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
        _logger.LogInformation($"API inicio a las:{DateTime.Now}");
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogInformation($"Error de la Api registrado a las:{DateTime.Now}");
        _logger.LogError(context.Exception, context.Exception.Message);
        base.OnException(context);
    }
}