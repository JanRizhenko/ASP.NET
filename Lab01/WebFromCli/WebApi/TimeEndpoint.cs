namespace WebFromCli.WebApi
{
    public class TimeEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
           await context.Response.WriteAsync(DateTime.Now.ToString());
        }
    }
}
