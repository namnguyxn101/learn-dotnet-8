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

app.MapGet("/cookies/{*action}", async (string? action, HttpContext context) =>
{
    var menu = HtmlHelper.MenuTop(
        HtmlHelper.DefaultMenuTopItems(),
        context.Request
    );

    // var action = context.GetRouteValue("action") ?? "read";
    action ??= "read";

    string message = "";

    // if (action.ToString() == "write")
    if (action == "write")
    {
        var option = new CookieOptions()
        {
            Path = "/",
            Expires = DateTime.Now.AddDays(1)  
        };
        
        context.Response.Cookies.Append("MaSanPham", "1lk2nvkfsajo234lk", option);
        message = "Cookie duoc ghi";
    }
    else
    {
        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
        message = string.Join("", listcokie).HtmlTag("ul");
    }

    var link = "<a href=\"/cookies/read\" class=\"btn btn-danger\">Read cookie</a><a href=\"/cookies/write\" class=\"btn btn-success\">Write cookie</a>";
    link = link.HtmlTag("div", "container mt-4");
    message = message.HtmlTag("div", "alert alert-danger");

    var html = HtmlHelper.HtmlDocument($"Cookie: {action}", menu + link + message);

    await context.Response.WriteAsync(html);
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
