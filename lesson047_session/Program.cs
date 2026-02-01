var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDistributedMemoryCache();
builder.Services.AddDistributedSqlServerCache((option) =>
{
    option.ConnectionString = "Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=Password123;TrustServerCertificate=true";
    option.SchemaName = "dbo";
    option.TableName = "Session";
});
builder.Services.AddSession((option) =>
{
    option.Cookie.Name = "cookietest";
    option.IdleTimeout = new TimeSpan(0, 30, 0); // 30 minutes
});

var app = builder.Build();

app.UseSession(); // SessionMiddleware - Cookie (ID Session)

app.MapGet("/", async (context) =>
{
    int? count;

    count = context.Session.GetInt32("count"); // Read session

    if (count == null)
    {
        count = 0;
    }

    await context.Response.WriteAsync($"So lan truy cap readwritesession la {count}\n");
});

app.MapGet("/readwritesession", async (context) =>
{
    int? count;

    count = context.Session.GetInt32("count"); // Read session

    if (count == null)
    {
        count = 0;
    }

    count++;

    context.Session.SetInt32("count", count.Value); // Write session
    // context.Session.SetString(); - json (NewtonsoftJson)

    await context.Response.WriteAsync($"So lan truy cap readwritesession la {count}\n");
});

app.Run();
