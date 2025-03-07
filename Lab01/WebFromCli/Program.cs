using WebFromCli.WebApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/who", NameEndpoint.Endpoint);
app.MapGet("/time", TimeEndpoint.Endpoint);

app.Run();