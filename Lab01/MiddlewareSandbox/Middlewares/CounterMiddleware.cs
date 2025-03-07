using static System.Net.Mime.MediaTypeNames;

namespace MiddlewareSandbox.Middlewares
{
    public class CounterMiddleware
    {
        private RequestDelegate _next;
        private int _counter = 0;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            _counter++;
            await _next(ctx);
            await ctx.Response.WriteAsync($"\nThe amount of processed requests is: {_counter}\n");
        }
    }
}
