using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MiddlewareSandbox.Middlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

       public async Task Invoke(HttpContext ctx)
           {
           if (ctx.Request.Query.ContainsKey("custom"))
           {
                await ctx.Response.WriteAsync("You've hit a custom middleware!");
           }    
           else
           {
                await _next(ctx);
           }
       }
    }
}
