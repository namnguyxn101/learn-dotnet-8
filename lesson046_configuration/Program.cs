using System.Text;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.Configure<TestOptions>(builder.Configuration.GetSection("TestOptions"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/show-options", async (context) =>
{
    var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>()?.Value;

    var stringBuilder = new StringBuilder();

    stringBuilder.Append("TEST OPTIONS\n");
    stringBuilder.Append($"opt_key1 = {testOptions?.opt_key1}\n");
    stringBuilder.Append($"TestOptions.opt_key2.k1 = {testOptions?.opt_key2?.k1}\n");
    stringBuilder.Append($"TestOptions.opt_key2.k2 = {testOptions?.opt_key2?.k2}\n");

    await context.Response.WriteAsync(stringBuilder.ToString());
});

app.Run();
