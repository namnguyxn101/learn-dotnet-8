using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async (context) =>
{
    var menu = HtmlHelper.MenuTop(
        HtmlHelper.DefaultMenuTopItems(),
        context.Request
    );

    var html = HtmlHelper.HtmlDocument("Xin chao", menu + HtmlHelper.HtmlTrangchu());

    await context.Response.WriteAsync(html);
});

app.MapGet("/request-info", async (context) =>
{
    var menu = HtmlHelper.MenuTop(
        HtmlHelper.DefaultMenuTopItems(),
        context.Request
    );

    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container mt-4");

    var html = HtmlHelper.HtmlDocument("Thong tin request", menu + info);

    await context.Response.WriteAsync(html);
});

app.MapGet("/encoding", async (context) =>
{
    await context.Response.WriteAsync("Encoding");
});

app.MapGet("/cookies", async (context) =>
{
    await context.Response.WriteAsync("Cookies");
});

app.MapGet("/json", async (context) =>
{
    var menu = HtmlHelper.MenuTop(
        HtmlHelper.DefaultMenuTopItems(),
        context.Request
    );

    var p = new
    {
        Name = "Dong ho Abc",
        Price = 5000000,
        ManufactoringDate = new DateTime(2000, 12, 31)
    };

    context.Response.ContentType = "application/json";

    var json = JsonConvert.SerializeObject(p);

    await context.Response.WriteAsync(json);
});

app.MapGet("/form", async (context) =>
{
    await context.Response.WriteAsync("Form");
});

app.Run();
