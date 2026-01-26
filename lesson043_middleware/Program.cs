var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SecondMiddleware>();

var app = builder.Build();

app.UseStatusCodePages();

app.UseStaticFiles();

// app.UseMiddleware<FirstMiddleware>();
app.UseFirstMiddleware();
app.UseSecondMiddleware();

app.MapGet("/", async (context) =>
{
    await context.Response.WriteAsync("Hello World");
});

app.Map("/xinchao", async (context) =>
{
    await context.Response.WriteAsync("Xin chao ASP.NET Core");
});

app.Map("/admin", (appBranch) =>
{
    appBranch.UseRouting();

    appBranch.UseEndpoints((endpoint) =>
    {
        endpoint.MapGet("/users", async (context) =>
        {
            await context.Response.WriteAsync("Trang quan ly User");
        });

        endpoint.MapGet("/products", async (context) =>
        {
            await context.Response.WriteAsync("Trang quan ly Product");
        });
    });

    appBranch.Run(async (context) =>
    {
        await context.Response.WriteAsync("Trang Dashboard");
    });
});

app.Run();
