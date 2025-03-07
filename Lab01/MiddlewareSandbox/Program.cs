using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiddlewareSandbox.Middlewares;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<CheckApiKeyMiddleware>();
app.UseMiddleware<CounterMiddleware>();
app.UseMiddleware<CustomMiddleware>();

app.Run();
