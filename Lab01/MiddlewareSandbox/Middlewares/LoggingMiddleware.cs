using static System.Net.Mime.MediaTypeNames;

namespace MiddlewareSandbox.Middlewares
{
    public class LoggingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<LoggingMiddleware> _logger;


        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext ctx)
        {
            _logger.LogInformation($"Request: {ctx.Request.Method} {ctx.Request.Path}");
            await _next(ctx);
        }
    }   
}
