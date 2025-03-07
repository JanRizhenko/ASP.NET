namespace WebFromCli.WebApi
{
    public class NameEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            await context.Response.WriteAsync("Rizhenko Jan");
        }
    }
}
