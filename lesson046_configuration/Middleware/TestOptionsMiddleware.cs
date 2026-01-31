using System.Text;
using Microsoft.Extensions.Options;

public class TestOptionsMiddleware : IMiddleware
{
    TestOptions TestOptions { get; set; }

    public TestOptionsMiddleware(IOptions<TestOptions> options)
    {
        TestOptions = options.Value;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Show options in TestOptionsMiddleware\n");

        var stringBuilder = new StringBuilder();

        stringBuilder.Append("TEST OPTIONS\n");
        stringBuilder.Append($"opt_key1 = {TestOptions?.opt_key1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k1 = {TestOptions?.opt_key2?.k1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k2 = {TestOptions?.opt_key2?.k2}\n");

        await context.Response.WriteAsync(stringBuilder.ToString());

        await next(context);
    }
}