namespace MiddlewareSandbox.Middlewares
{
    public class CheckApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validApiKey = "my-secret-key";

        public CheckApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (!ctx.Request.Headers.TryGetValue("X-API-KEY", out var apiKey) || apiKey != _validApiKey)
            {
                ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                await ctx.Response.WriteAsync("Forbidden: Invalid API Key");
                return;
            }

            await _next(ctx);
        }
    }
}
