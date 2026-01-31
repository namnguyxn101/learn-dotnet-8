using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/show-options", async (context) =>
{
    var configuration = context.RequestServices.GetService<IConfiguration>();

    var testOptions = configuration?.GetSection("TestOptions");
    var opt_key1 = testOptions?["opt_key1"];

    var k1 = testOptions?.GetSection("opt_key2")["k1"];
    var k2 = testOptions?.GetSection("opt_key2")["k2"];

    var stringBuilder = new StringBuilder();

    stringBuilder.Append("TEST OPTIONS\n");
    stringBuilder.Append($"opt_key1 = {opt_key1}\n");
    stringBuilder.Append($"TestOptions.opt_key2.k1 = {k1}\n");
    stringBuilder.Append($"TestOptions.opt_key2.k2 = {k2}\n");

    await context.Response.WriteAsync(stringBuilder.ToString());
});

app.Run();
